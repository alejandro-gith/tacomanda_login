# Recorridos explícitos en archivos propios

El patrón Mediator se implementa dentro del proyecto. No existe una dependencia de MediatR.
El Command lleva datos; no ejecuta al validator, consulta datos ni conoce el tipo de respuesta.
El orden de las llamadas está escrito en el mediador. Las interfaces se enlazan con sus implementaciones de forma explícita en Application/DependencyInjection.cs.

## Login

1. InicioSesionComponent captura usuario y contraseña en InicioSesionViewModel.
2. InicioSesionFacade valida lo visual y llama a AuthApiClient.
3. AuthApiClient envía POST /api/auth/login.
4. AuthController crea IniciarSesionCommand y llama a IIniciarSesionMediator.EnviarAsync.
5. IniciarSesionMediator llama a IIniciarSesionValidator.Validar, implementado por IniciarSesionValidator.
6. Si la validación termina correctamente, IniciarSesionMediator llama a IIniciarSesionHandler.Handle, implementado por IniciarSesionHandler.
7. El handler consulta IEmpleadoRepository → EmpleadoRepository → TacomandaDbContext → BD.
8. El handler verifica la contraseña mediante IPasswordHasher y genera el token mediante ITokenService.
9. SesionDto vuelve: Handler → Mediator propio → Controller (200) → AuthApiClient → Facade → SessionStore/ViewModel → pantalla.

Código de IniciarSesionMediator:

```csharp
_validator.Validar(solicitud);
return await _handler.Handle(solicitud, cancellationToken);
```

## Crear comanda

1. CrearComandaComponent captura mesa, platillos, cantidades y notas en CrearComandaViewModel.
2. CrearComandaFacade prepara el JSON y llama a ComandasApiClient.
3. ComandasApiClient envía POST /api/comandas. El interceptor adjunta el JWT.
4. El middleware de autenticación valida el JWT y la autorización exige rol Mesero.
5. ComandasController delega la construcción de CrearComandaCommand a ICrearComandaCommandFactory; la factory usa IUsuarioActual para obtener el ID auténtico.
6. ComandasController llama a ICrearComandaMediator.EnviarAsync.
7. CrearComandaMediator llama explícitamente a ICrearComandaValidator.Validar.
8. Al terminar correctamente, el mediador llama a ICrearComandaHandler.Handle.
9. El handler usa IMesaRepository e IPlatilloRepository; para verificar al mesero usa IMeseroReader → MeseroReader → IMeseroRepository.
10. Las implementaciones Repository son las que consultan TacomandaDbContext.
11. DetalleComanda y Comanda protegen cantidades y total; Mesa protege su disponibilidad.
12. IComandaRepository → ComandaRepository agrega la comanda y detalles al contexto.
13. IUnidadDeTrabajo → UnidadDeTrabajoRepository confirma comanda y mesa en una transacción.
14. El mapper produce ComandaDto. Regresa por Handler → Mediator propio → Controller (201) → ComandasApiClient → Facade → ViewModel → pantalla.

Código de CrearComandaMediator:

```csharp
public async Task<ComandaDto> EnviarAsync(
    CrearComandaCommand solicitud,
    CancellationToken cancellationToken)
{
    _validator.Validar(solicitud);

    return await _handler.Handle(solicitud, cancellationToken);
}
```

Si Validar lanza una excepción, Handle no se ejecuta. ExceptionMiddleware produce la respuesta genérica con el código HTTP apropiado.

## Lecturas

MesasController → ConsultarMesasQuery → ConsultarMesasMediator → ConsultarMesasQueryHandler → IMesaReader / MesaReader → IMesasLecturaRepository / MesasLecturaRepository → TacomandaDbContext → BD.

PlatillosController → ConsultarPlatilloQuery → ConsultarPlatilloMediator → ConsultarPlatilloQueryHandler → IPlatilloReader / PlatilloReader → IPlatillosLecturaRepository / PlatillosLecturaRepository → TacomandaDbContext → BD.

Los readers conservan sus nombres CRC pero no acceden directamente al contexto: delegan al repositorio. Esta adaptación aplica la instrucción más reciente de que solo los repositorios consulten la BD.

## Controller de creación

```csharp
[HttpPost]
public async Task<ActionResult<ComandaDto>> Crear(
    CrearComandaRequest request,
    CancellationToken cancellationToken)
{
    CrearComandaCommand command = _commandFactory.Crear(request);
    ComandaDto respuesta = await _mediator.EnviarAsync(command, cancellationToken);
    return StatusCode(StatusCodes.Status201Created, respuesta);
}
```

El DTO de retorno del handler/controller sigue existiendo porque hay que enviar datos al frontend. No es una conexión, entidad persistida ni repositorio.
Solo se eliminó la asociación entre Command y tipo de respuesta que exigía la biblioteca de mediación.

## Registro explícito

```csharp
services.AddTransient<ICrearComandaValidator, CrearComandaValidator>();
services.AddTransient<ICrearComandaHandler, CrearComandaHandler>();
services.AddTransient<ICrearComandaMediator, CrearComandaMediator>();
```

El framework sigue proporcionando HTTP, inyección de dependencias y autenticación; EF Core sigue siendo el motor de persistencia. La mediación y el orden de validación/ejecución son código propio.

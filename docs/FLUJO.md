# Recorrido de los flujos

La API usa MediatR 12.4.1: los controllers inyectan `ISender` y envían comandos o consultas con `Send`. MediatR resuelve el handler registrado. El pipeline `ValidationBehavior<TRequest,TResponse>` ejecuta los `IValidator<TRequest>` registrados antes del handler. No hay un mediador escrito por cada caso de uso.

`IRequest<ComandaDto>` en `CrearComandaCommand` declara el tipo de respuesta de MediatR. No consulta la base de datos. El comando solo transporta IDs y detalles.

## Inicio de sesión

1. `InicioSesionComponent` y `InicioSesionViewModel` capturan usuario y contraseña.
2. `InicioSesionFacade` llama a `AuthApiClient`, que envía `POST /api/auth/login`.
3. `AuthController` crea `IniciarSesionCommand` y llama a `ISender.Send`.
4. MediatR ejecuta `ValidationBehavior`; este invoca `IniciarSesionValidator` mediante `IValidator<IniciarSesionCommand>`.
5. MediatR invoca `IniciarSesionHandler`, que usa `IEmpleadoRepository` → `EmpleadoRepository` para buscar al empleado, `IPasswordHasher` para comprobar la clave y `ITokenService` para generar el JWT.
6. `SesionDto` vuelve por handler → MediatR → controller (200) → cliente HTTP → facade → estado de sesión y pantalla.

## Crear comanda

1. `CrearComandaComponent` y `CrearComandaViewModel` capturan mesa, platillos, cantidades y observaciones.
2. `CrearComandaFacade` llama a `ComandasApiClient`; este envía `POST /api/comandas` con el JWT adjunto por el interceptor.
3. La autenticación valida el JWT y la autorización requiere el rol Mesero.
4. `ComandasController` usa `ICrearComandaCommandFactory`; esta obtiene el ID real mediante `IUsuarioActual` y crea `CrearComandaCommand`.
5. El controller llama a `ISender.Send`. MediatR ejecuta `ValidationBehavior` → `CrearComandaValidator` → `CrearComandaHandler`.
6. El handler consulta `IMesaRepository`, `IMeseroRepository` e `IPlatilloRepository`. **La consulta de mesero va directamente al repositorio**, igual que mesa y platillo; no hay `MeseroReader` de paso.
7. `DetalleComanda`, `Comanda` y `Mesa` preservan reglas de cantidades, total y disponibilidad.
8. `IComandaRepository` agrega la comanda; `IUnidadDeTrabajo` confirma comanda y ocupación de mesa en la misma transacción.
9. `IMapper.Map<ComandaDto>(comanda)` aplica `ComandaMappingProfile`, incluidos los detalles. El DTO vuelve por handler → MediatR → controller (201) → cliente HTTP → facade → ViewModel → pantalla.

## Consultar mesas y platillos

`MesasController` → `ConsultarMesasQuery` → MediatR → `ConsultarMesasQueryHandler` → `IMesaReader` / `MesaReader` → `IMesasLecturaRepository` / `MesasLecturaRepository` → BD. AutoMapper convierte cada mesa en `MesaDto`.

`PlatillosController` → `ConsultarPlatilloQuery` → MediatR → `ConsultarPlatilloQueryHandler` → `IPlatilloReader` / `PlatilloReader` → `IPlatillosLecturaRepository` / `PlatillosLecturaRepository` → BD. AutoMapper convierte los resultados filtrados en `PlatilloDto`.

Los readers de las tarjetas CRC siguen presentes en estas consultas; delegan el acceso físico a repositories. Únicamente los archivos Repository ejecutan las consultas y guardados de datos.

## Registro y errores

`Application/DependencyInjection.cs` registra MediatR, el pipeline de validación, los validators y AutoMapper. `Infrastructure/DependencyInjection.cs` conecta interfaces de datos con repositories. Los errores del validator o handler se traducen mediante `ExceptionMiddleware` a un estado HTTP apropiado y el mensaje genérico para el usuario; el detalle técnico queda en la consola.

# Tarjeta → archivo → responsabilidad

Fuente: páginas 1 y 2 de [TACOMANDA_TARJETAS_SRC.pdf](referencias/TACOMANDA_TARJETAS_SRC.pdf).
El proyecto anterior agrupaba tipos en Auth.cs/Orders.cs e InMemoryDatabase y usaba nombres distintos. Esta entrega reemplaza esa estructura.

## 01. Inicio de sesión

| Clase de la tarjeta | Archivo | Responsabilidad de la tarjeta |
|---|---|---|
| InicioSesionComponent | [InicioSesionComponent.ts](../frontend/src/app/features/inicio-sesion/InicioSesionComponent.ts) | Capturar usuario y contraseña; mostrar errores y sesión iniciada. |
| InicioSesionViewModel | [InicioSesionViewModel.ts](../frontend/src/app/features/inicio-sesion/InicioSesionViewModel.ts) | Mantener usuario, contraseña, loading y mensajes. |
| InicioSesionFacade | [InicioSesionFacade.ts](../frontend/src/app/features/inicio-sesion/InicioSesionFacade.ts) | Validar datos visuales, llamar al cliente y guardar la sesión. |
| AuthApiClient | [AuthApiClient.ts](../frontend/src/app/core/api/AuthApiClient.ts) | Enviar POST /api/auth/login. |
| AuthController | [AuthController.cs](../backend/src/Tacomanda.Api/Controllers/AuthController.cs) | Recibir credenciales y crear el comando. |
| IniciarSesionCommand | [IniciarSesionCommand.cs](../backend/src/Tacomanda.Application/InicioSesion/IniciarSesionCommand.cs) | Transportar usuario y contraseña. |
| IniciarSesionValidator | [IniciarSesionValidator.cs](../backend/src/Tacomanda.Application/InicioSesion/IniciarSesionValidator.cs) | Validar campos requeridos y longitud de contraseña. |
| IniciarSesionHandler | [IniciarSesionHandler.cs](../backend/src/Tacomanda.Application/InicioSesion/IniciarSesionHandler.cs) | Buscar empleado, verificar contraseña y generar token. |
| EmpleadoRepository | [EmpleadoRepository.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/EmpleadoRepository.cs) | Consultar el empleado en la base de datos. |

## 02. Crear comanda

| Clase de la tarjeta | Archivo | Responsabilidad de la tarjeta |
|---|---|---|
| CrearComandaComponent | [CrearComandaComponent.ts](../frontend/src/app/features/crear-comanda/CrearComandaComponent.ts) | Seleccionar mesa, platillos y cantidades. |
| CrearComandaViewModel | [CrearComandaViewModel.ts](../frontend/src/app/features/crear-comanda/CrearComandaViewModel.ts) | Mantener carrito, mesa seleccionada y total. |
| CrearComandaFacade | [CrearComandaFacade.ts](../frontend/src/app/features/crear-comanda/CrearComandaFacade.ts) | Preparar la comanda y enviarla. |
| ComandasApiClient | [ComandasApiClient.ts](../frontend/src/app/core/api/ComandasApiClient.ts) | Enviar POST /api/comandas. |
| ComandasController | [ComandasController.cs](../backend/src/Tacomanda.Api/Controllers/ComandasController.cs) | Recibir datos y crear el command. |
| CrearComandaCommand | [CrearComandaCommand.cs](../backend/src/Tacomanda.Application/CrearComanda/CrearComandaCommand.cs) | Transportar mesa, mesero y detalles. |
| CrearComandaValidator | [CrearComandaValidator.cs](../backend/src/Tacomanda.Application/CrearComanda/CrearComandaValidator.cs) | Validar IDs, cantidades y observaciones. |
| CrearComandaHandler | [CrearComandaHandler.cs](../backend/src/Tacomanda.Application/CrearComanda/CrearComandaHandler.cs) | Verificar mesa, platillos y mesero; crear la comanda. |
| ComandaRepository | [ComandaRepository.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/ComandaRepository.cs) | Guardar la comanda y sus detalles. |
| Comanda | [Comanda.cs](../backend/src/Tacomanda.Domain/Comandas/Comanda.cs) | Proteger reglas como cantidades válidas y total. |

## Colaboradores y soporte: no son tarjetas nuevas

Las tarjetas enumeran clases y colaboraciones, no todos los archivos de infraestructura necesarios para ejecutar ASP.NET Core y Angular.
Los siguientes componentes se identifican explícitamente como soporte; no se atribuyen responsabilidades inventadas a las tarjetas.

| Archivo/clase | Responsabilidad técnica y motivo |
|---|---|
| IEmpleadoRepository.cs | Solo buscar por usuario para login. |
| IMeseroRepository.cs / MeseroRepository.cs | Consultar directamente al mesero por ID desde CrearComandaHandler, sin reader intermedio. |
| IMesaRepository.cs / MesaRepository.cs | Obtener la mesa del caso de creación. No contiene operaciones de cobro. |
| IPlatilloRepository.cs / PlatilloRepository.cs | Obtener el platillo usado al crear la comanda. |
| IComandaRepository.cs | Agregar una comanda. Sin CRUD genérico ni métodos de otros flujos. |
| IUnidadDeTrabajo.cs | Confirmar los cambios del caso de uso; separa la transacción de la operación de cada repositorio. |
| TacomandaDbContext.cs | Modelo EF Core utilizado por los repositorios. |
| UnidadDeTrabajoRepository.cs | Confirmación transaccional de los cambios de comanda y mesa. |
| DetalleComanda.cs | Encapsular cantidad, precio capturado, observación y subtotal; colaborador nombrado en la tarjeta de Comanda. |
| Mesa.cs | Proteger su disponibilidad; Ocupar no permite ocupar dos veces. |
| IPasswordHasher.cs | Verificar contraseñas para login. |
| IPasswordEncoder.cs | Codificar contraseñas exclusivamente al sembrar datos. El handler no depende de esta operación. |
| ITokenService.cs / JwtTokenService.cs | Contrato y generación del token; el handler coordina su uso. |
| SessionStore.ts | Guardar y recuperar la sesión; colaborador explícito de InicioSesionFacade. |
| IUsuarioActual.cs / UsuarioActual.cs | Acceder al identificador de la identidad autenticada. Solo la implementación conoce HttpContext/claims. |
| ICrearComandaCommandFactory.cs / CrearComandaCommandFactory.cs | Construir el command con la identidad del servidor. No valida reglas ni consulta BD. |
| MediatR / ValidationBehavior.cs | MediatR resuelve los handlers; el pipeline llama a IValidator<T> antes del handler. |
| IRequestHandler<TRequest,TResponse> | Contrato de MediatR implementado por cada handler. |
| IValidator<T> | Contrato pequeño implementado por los validators de login y crear comanda. |
| MesasLecturaRepository.cs / PlatillosLecturaRepository.cs / MeseroRepository.cs | Acceso a datos delegado por los readers; interfaces separadas por consumidor. |
| DatosDePruebaRepository.cs | Consultar y guardar los datos iniciales; el seeder no accede al contexto. |
| ComandaMappingProfile.cs / AutoMapper | Transformar entidades y detalles en DTOs sin introducir reglas. |
| ExceptionMiddleware.cs | Convertir fallos a estados HTTP y mensaje genérico; registrar detalle técnico. |

## Lecturas de apoyo

Se reutilizan los nombres backend de la tarjeta 06: `PlatillosController`, `ConsultarPlatilloQuery`, `ConsultarPlatilloQueryHandler`, `IPlatilloReader`, `PlatilloReader`, `PlatilloDto` y `PlatillosApiClient`.
La consulta de mesas requiere `MesasController`, `ConsultarMesasQuery`, `ConsultarMesasQueryHandler`, `IMesaReader`, `MesaReader`, `MesaDto` y `MesasApiClient`.
Se consumen desde la captura de comanda. No se añade una pantalla completa del flujo 06.

## SOLID aplicado

- **S:** componentes capturan/renderizan; ViewModels mantienen estado; facades coordinan; clientes hacen HTTP; controllers traducen HTTP a comandos y respuesta; validators revisan formato; handlers coordinan el caso; entidades protegen invariantes; repositorios acceden al almacenamiento.
- **O:** cada caso nuevo tiene sus propios contratos, mediador, validator y handler; no requiere modificar un despachador con switch ni otros casos.
- **L:** los contratos de repositorio conservan las mismas expectativas: consulta inexistente devuelve null; agregar prepara persistencia; confirmar es atómico. Cambiar implementación exige mantener esos contratos.
- **I:** no existe un IRepository genérico con CRUD obligatorio. Se separan lookup de empleado, lectura de mesero, lectura de catálogo, escritura de comanda, transacción, verificación y codificación de contraseña. Cada controller depende únicamente de la interfaz de su mediador; no depende de operaciones de otros casos.
- **D:** Application depende de interfaces de datos y seguridad. Domain no referencia Application, API ni EF Core. Infrastructure implementa los contratos; Program.cs registra las implementaciones.

La relación ViewModel–Facade de CRC es una colaboración sobre el estado: la vista enlaza el ViewModel y dispara acciones de la Facade. No se introduce una dependencia circular entre ambos para simular una cadena literal de llamadas.

## Ajuste solicitado: solamente repositories consultan datos

Los Readers de las consultas conservan su responsabilidad de lectura y delegan el acceso físico a repositorios segregados. El handler de crear comanda usa IMeseroRepository directamente. MediatR invoca un único ValidationBehavior que valida antes de llamar al handler. Los comandos implementan IRequest<TRespuesta> para declarar la respuesta; siguen transportando solo datos y no acceden a la base.

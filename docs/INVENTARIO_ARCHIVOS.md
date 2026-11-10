# Inventario de archivos y responsabilidades

Rutas relativas a la raíz del proyecto. MAPA_CRC.md distingue clases literales de las tarjetas y soporte técnico. La mediación usa MediatR y el mapeo usa AutoMapper.

## backend

| Archivo | Función |
|---|---|
| [backend/Directory.Build.props](../backend/Directory.Build.props) | Establecer net10.0, nulabilidad y advertencias como errores para las cuatro capas. |
| [backend/Tacomanda.sln](../backend/Tacomanda.sln) | Agrupar los proyectos backend y sus configuraciones de compilación. |
| [backend/src/Tacomanda.Api/Configuration/ApiBehaviorConfiguration.cs](../backend/src/Tacomanda.Api/Configuration/ApiBehaviorConfiguration.cs) | Responder 400 genérico ante errores de JSON/enlace del contrato HTTP; registrar trazabilidad. |
| [backend/src/Tacomanda.Api/Configuration/CorsConfiguration.cs](../backend/src/Tacomanda.Api/Configuration/CorsConfiguration.cs) | Configurar el origen Angular permitido. |
| [backend/src/Tacomanda.Api/Configuration/JwtBearerConfiguration.cs](../backend/src/Tacomanda.Api/Configuration/JwtBearerConfiguration.cs) | Configurar la validación JWT y exigir un identificador válido; callbacks con nombre. |
| [backend/src/Tacomanda.Api/Contracts/CrearComandaRequest.cs](../backend/src/Tacomanda.Api/Contracts/CrearComandaRequest.cs) | Contrato HTTP de mesa y detalles. No acepta el ID del mesero como autoridad. |
| [backend/src/Tacomanda.Api/Contracts/ErrorResponse.cs](../backend/src/Tacomanda.Api/Contracts/ErrorResponse.cs) | Transportar estado, mensaje genérico y traceId de un fallo. |
| [backend/src/Tacomanda.Api/Contracts/IniciarSesionRequest.cs](../backend/src/Tacomanda.Api/Contracts/IniciarSesionRequest.cs) | Contrato HTTP de usuario y contraseña. |
| [backend/src/Tacomanda.Api/Controllers/AuthController.cs](../backend/src/Tacomanda.Api/Controllers/AuthController.cs) | Recibir credenciales y crear el comando. |
| [backend/src/Tacomanda.Api/Controllers/ComandasController.cs](../backend/src/Tacomanda.Api/Controllers/ComandasController.cs) | Recibir datos y crear el command. |
| [backend/src/Tacomanda.Api/Controllers/MesasController.cs](../backend/src/Tacomanda.Api/Controllers/MesasController.cs) | Enviar ConsultarMesasQuery mediante su mediador propio y devolver su respuesta. |
| [backend/src/Tacomanda.Api/Controllers/PlatillosController.cs](../backend/src/Tacomanda.Api/Controllers/PlatillosController.cs) | Crear ConsultarPlatilloQuery, enviarla mediante su mediador propio y devolver su respuesta. |
| [backend/src/Tacomanda.Api/Mapping/CrearComandaCommandFactory.cs](../backend/src/Tacomanda.Api/Mapping/CrearComandaCommandFactory.cs) | Ensamblar CrearComandaCommand a partir del request y de IUsuarioActual. |
| [backend/src/Tacomanda.Api/Mapping/ICrearComandaCommandFactory.cs](../backend/src/Tacomanda.Api/Mapping/ICrearComandaCommandFactory.cs) | Contrato de una sola operación para ensamblar el command. |
| [backend/src/Tacomanda.Api/Middleware/ExceptionMiddleware.cs](../backend/src/Tacomanda.Api/Middleware/ExceptionMiddleware.cs) | Traducir excepciones a HTTP, registrar detalle y ocultarlo al usuario. |
| [backend/src/Tacomanda.Api/Middleware/RegistroHttpMiddleware.cs](../backend/src/Tacomanda.Api/Middleware/RegistroHttpMiddleware.cs) | Registrar método, ruta, estado HTTP y traceId sin cuerpos, tokens ni contraseñas. |
| [backend/src/Tacomanda.Api/Middleware/StatusCodeResponder.cs](../backend/src/Tacomanda.Api/Middleware/StatusCodeResponder.cs) | Producir cuerpo de error genérico para respuestas sin cuerpo, por ejemplo 401 y 403. |
| [backend/src/Tacomanda.Api/Program.cs](../backend/src/Tacomanda.Api/Program.cs) | Registrar dependencias, inicializar datos de prueba y componer el pipeline HTTP. |
| [backend/src/Tacomanda.Api/Properties/launchSettings.json](../backend/src/Tacomanda.Api/Properties/launchSettings.json) | Definir puerto y entorno local de ejecución. |
| [backend/src/Tacomanda.Api/Seguridad/UsuarioActual.cs](../backend/src/Tacomanda.Api/Seguridad/UsuarioActual.cs) | Implementar IUsuarioActual leyendo exclusivamente la identidad de la petición autenticada. |
| [backend/src/Tacomanda.Api/Tacomanda.Api.csproj](../backend/src/Tacomanda.Api/Tacomanda.Api.csproj) | Declarar referencias y dependencias del proyecto Tacomanda.Api. |
| [backend/src/Tacomanda.Api/appsettings.json](../backend/src/Tacomanda.Api/appsettings.json) | Configurar niveles de registro y hosts; no contiene claves JWT ni contraseñas. |
| [backend/src/Tacomanda.Application/ConsultarMesas/ConsultarMesasQuery.cs](../backend/src/Tacomanda.Application/ConsultarMesas/ConsultarMesasQuery.cs) | Transportar la intención de consultar mesas. |
| [backend/src/Tacomanda.Application/ConsultarMesas/ConsultarMesasQueryHandler.cs](../backend/src/Tacomanda.Application/ConsultarMesas/ConsultarMesasQueryHandler.cs) | Consultar IMesaReader y transformar las mesas a DTO. |
| [backend/src/Tacomanda.Application/ConsultarMesas/IMesaReader.cs](../backend/src/Tacomanda.Application/ConsultarMesas/IMesaReader.cs) | Contrato de lectura de la lista de mesas. |
| [backend/src/Tacomanda.Application/ConsultarMesas/MesaDto.cs](../backend/src/Tacomanda.Application/ConsultarMesas/MesaDto.cs) | Representar identificador, nombre y disponibilidad de una mesa. |
| [backend/src/Tacomanda.Application/ConsultarPlatillo/ConsultarPlatilloQuery.cs](../backend/src/Tacomanda.Application/ConsultarPlatillo/ConsultarPlatilloQuery.cs) | Transportar filtros y paginación de la tarjeta 06. |
| [backend/src/Tacomanda.Application/ConsultarPlatillo/ConsultarPlatilloQueryHandler.cs](../backend/src/Tacomanda.Application/ConsultarPlatillo/ConsultarPlatilloQueryHandler.cs) | Consultar IPlatilloReader y convertir los platillos filtrados a DTO. |
| [backend/src/Tacomanda.Application/ConsultarPlatillo/IPlatilloReader.cs](../backend/src/Tacomanda.Application/ConsultarPlatillo/IPlatilloReader.cs) | Contrato de lectura del catálogo; sin operaciones de escritura. |
| [backend/src/Tacomanda.Application/ConsultarPlatillo/PlatilloDto.cs](../backend/src/Tacomanda.Application/ConsultarPlatillo/PlatilloDto.cs) | Representar la respuesta de catálogo para Angular. |
| [backend/src/Tacomanda.Application/CrearComanda/CrearComandaCommand.cs](../backend/src/Tacomanda.Application/CrearComanda/CrearComandaCommand.cs) | Transportar mesa, mesero y detalles. |
| [backend/src/Tacomanda.Application/CrearComanda/CrearComandaHandler.cs](../backend/src/Tacomanda.Application/CrearComanda/CrearComandaHandler.cs) | Verificar mesa, platillos y mesero; crear la comanda. |
| [backend/src/Tacomanda.Application/CrearComanda/CrearComandaValidator.cs](../backend/src/Tacomanda.Application/CrearComanda/CrearComandaValidator.cs) | Validar IDs, cantidades y observaciones. |
| [backend/src/Tacomanda.Application/CrearComanda/DetalleComandaInput.cs](../backend/src/Tacomanda.Application/CrearComanda/DetalleComandaInput.cs) | Transportar ID de platillo, cantidad y observaciones; sin precio recibido del cliente. |
| [backend/src/Tacomanda.Application/DependencyInjection.cs](../backend/src/Tacomanda.Application/DependencyInjection.cs) | Registrar explícitamente cada mediador, validator y handler propios por su interfaz; registrar mapper. |
| [backend/src/Tacomanda.Application/InicioSesion/IniciarSesionCommand.cs](../backend/src/Tacomanda.Application/InicioSesion/IniciarSesionCommand.cs) | Transportar usuario y contraseña. |
| [backend/src/Tacomanda.Application/InicioSesion/SesionDto.cs](../backend/src/Tacomanda.Application/InicioSesion/SesionDto.cs) | Transportar datos de sesión y token como respuesta del handler. |
| [backend/src/Tacomanda.Application/Respuestas/ComandaDto.cs](../backend/src/Tacomanda.Application/Respuestas/ComandaDto.cs) | Transportar el resultado de comanda para Angular, separado de la entidad. |
| [backend/src/Tacomanda.Application/Respuestas/DetalleComandaDto.cs](../backend/src/Tacomanda.Application/Respuestas/DetalleComandaDto.cs) | Transportar el detalle creado y su subtotal. |
| [backend/src/Tacomanda.Application/Seguridad/IPasswordEncoder.cs](../backend/src/Tacomanda.Application/Seguridad/IPasswordEncoder.cs) | Contrato exclusivo de codificación de contraseña para datos de prueba. |
| [backend/src/Tacomanda.Application/Seguridad/IPasswordHasher.cs](../backend/src/Tacomanda.Application/Seguridad/IPasswordHasher.cs) | Contrato exclusivo de verificación de contraseña para login. |
| [backend/src/Tacomanda.Application/Seguridad/ITokenService.cs](../backend/src/Tacomanda.Application/Seguridad/ITokenService.cs) | Abstraer la generación de un token de sesión. |
| [backend/src/Tacomanda.Application/Seguridad/IUsuarioActual.cs](../backend/src/Tacomanda.Application/Seguridad/IUsuarioActual.cs) | Abstraer la obtención del identificador autenticado sin exponer HTTP a Application. |
| [backend/src/Tacomanda.Application/Seguridad/TokenDto.cs](../backend/src/Tacomanda.Application/Seguridad/TokenDto.cs) | Transportar el token y su vencimiento. |
| [backend/src/Tacomanda.Application/Tacomanda.Application.csproj](../backend/src/Tacomanda.Application/Tacomanda.Application.csproj) | Declarar referencias y dependencias del proyecto Tacomanda.Application. |
| [backend/src/Tacomanda.Application/Validacion/ValidacionException.cs](../backend/src/Tacomanda.Application/Validacion/ValidacionException.cs) | Representar un incumplimiento de formato de entrada. |
| [backend/src/Tacomanda.Domain/Comandas/Comanda.cs](../backend/src/Tacomanda.Domain/Comandas/Comanda.cs) | Proteger reglas como cantidades válidas y total. |
| [backend/src/Tacomanda.Domain/Comandas/DetalleComanda.cs](../backend/src/Tacomanda.Domain/Comandas/DetalleComanda.cs) | Proteger cantidad, precio capturado, observaciones y cálculo del subtotal. |
| [backend/src/Tacomanda.Domain/Comandas/OrderStatus.cs](../backend/src/Tacomanda.Domain/Comandas/OrderStatus.cs) | Definir nombres de estado del dominio; no expone operaciones de flujos fuera del alcance. |
| [backend/src/Tacomanda.Domain/Empleados/Empleado.cs](../backend/src/Tacomanda.Domain/Empleados/Empleado.cs) | Encapsular identidad, usuario, nombre, hash, rol y estado activo. |
| [backend/src/Tacomanda.Domain/Empleados/EmployeeRole.cs](../backend/src/Tacomanda.Domain/Empleados/EmployeeRole.cs) | Definir Administrador, Mesero y Cajero. |
| [backend/src/Tacomanda.Domain/Excepciones/ReglaDeNegocioException.cs](../backend/src/Tacomanda.Domain/Excepciones/ReglaDeNegocioException.cs) | Representar incumplimientos de invariantes de dominio. |
| [backend/src/Tacomanda.Domain/Interfaces/IComandaRepository.cs](../backend/src/Tacomanda.Domain/Interfaces/IComandaRepository.cs) | Contrato para agregar una comanda con sus detalles. |
| [backend/src/Tacomanda.Domain/Interfaces/IEmpleadoRepository.cs](../backend/src/Tacomanda.Domain/Interfaces/IEmpleadoRepository.cs) | Contrato para buscar un empleado por usuario. |
| [backend/src/Tacomanda.Domain/Interfaces/IMesaRepository.cs](../backend/src/Tacomanda.Domain/Interfaces/IMesaRepository.cs) | Contrato para obtener la mesa a usar en creación. |
| [backend/src/Tacomanda.Domain/Interfaces/IMesasLecturaRepository.cs](../backend/src/Tacomanda.Domain/Interfaces/IMesasLecturaRepository.cs) | Contrato específico de consulta de mesas. |
| [backend/src/Tacomanda.Domain/Interfaces/IMeseroRepository.cs](../backend/src/Tacomanda.Domain/Interfaces/IMeseroRepository.cs) | Contrato específico de consulta de mesero. |
| [backend/src/Tacomanda.Domain/Interfaces/IPlatilloRepository.cs](../backend/src/Tacomanda.Domain/Interfaces/IPlatilloRepository.cs) | Contrato para obtener el platillo del detalle que se quiere crear. |
| [backend/src/Tacomanda.Domain/Interfaces/IPlatillosLecturaRepository.cs](../backend/src/Tacomanda.Domain/Interfaces/IPlatillosLecturaRepository.cs) | Contrato específico de consulta de platillos. |
| [backend/src/Tacomanda.Domain/Interfaces/IUnidadDeTrabajo.cs](../backend/src/Tacomanda.Domain/Interfaces/IUnidadDeTrabajo.cs) | Contrato para confirmar el conjunto de cambios del caso de uso. |
| [backend/src/Tacomanda.Domain/Mesas/Mesa.cs](../backend/src/Tacomanda.Domain/Mesas/Mesa.cs) | Proteger la disponibilidad; ocupar la mesa e incrementar su versión. |
| [backend/src/Tacomanda.Domain/Platillos/Platillo.cs](../backend/src/Tacomanda.Domain/Platillos/Platillo.cs) | Encapsular catálogo, precio positivo y estado activo. |
| [backend/src/Tacomanda.Domain/Tacomanda.Domain.csproj](../backend/src/Tacomanda.Domain/Tacomanda.Domain.csproj) | Declarar referencias y dependencias del proyecto Tacomanda.Domain. |
| [backend/src/Tacomanda.Infrastructure/DependencyInjection.cs](../backend/src/Tacomanda.Infrastructure/DependencyInjection.cs) | Registrar repositorios segregados, readers delegados, conexión, seguridad, unidad de trabajo y siembra. |
| [backend/src/Tacomanda.Infrastructure/Persistence/BaseDeDatosMemoria.cs](../backend/src/Tacomanda.Infrastructure/Persistence/BaseDeDatosMemoria.cs) | Mantener viva la BD SQLite en memoria y configurar sus conexiones. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Configurations/ComandaConfiguration.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Configurations/ComandaConfiguration.cs) | Mapear comanda, relaciones y colección privada de detalles a EF Core. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Configurations/DetalleComandaConfiguration.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Configurations/DetalleComandaConfiguration.cs) | Mapear el detalle y su relación con platillo a EF Core. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Configurations/EmpleadoConfiguration.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Configurations/EmpleadoConfiguration.cs) | Mapear el empleado y el índice único de usuario a EF Core. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Configurations/MesaConfiguration.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Configurations/MesaConfiguration.cs) | Mapear la mesa y declarar su versión como token de concurrencia. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Configurations/PlatilloConfiguration.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Configurations/PlatilloConfiguration.cs) | Mapear el catálogo a EF Core. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Readers/MesaReader.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Readers/MesaReader.cs) | Delegar la lectura a IMesasLecturaRepository; sin acceso directo a BD. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Readers/PlatilloReader.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Readers/PlatilloReader.cs) | Delegar la lectura a IPlatillosLecturaRepository; sin acceso directo a BD. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Repositories/ComandaRepository.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/ComandaRepository.cs) | Guardar la comanda y sus detalles. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Repositories/DatosDePruebaRepository.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/DatosDePruebaRepository.cs) | Consultar existencia de datos, inicializar esquema y guardar empleados, mesas y platillos de prueba. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Repositories/EmpleadoRepository.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/EmpleadoRepository.cs) | Consultar el empleado en la base de datos. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Repositories/MesaRepository.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/MesaRepository.cs) | Obtener una mesa con seguimiento para guardar su cambio dentro de la transacción. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Repositories/MesasLecturaRepository.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/MesasLecturaRepository.cs) | Consultar mesas mediante TacomandaDbContext; único adaptador de datos de esta operación. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Repositories/MeseroRepository.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/MeseroRepository.cs) | Consultar mesero mediante TacomandaDbContext; único adaptador de datos de esta operación. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Repositories/PlatilloRepository.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/PlatilloRepository.cs) | Obtener el platillo y su precio vigente. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Repositories/PlatillosLecturaRepository.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/PlatillosLecturaRepository.cs) | Consultar platillos mediante TacomandaDbContext; único adaptador de datos de esta operación. |
| [backend/src/Tacomanda.Infrastructure/Persistence/Repositories/UnidadDeTrabajoRepository.cs](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/UnidadDeTrabajoRepository.cs) | Implementar IUnidadDeTrabajo y confirmar todos los cambios del contexto en una transacción. |
| [backend/src/Tacomanda.Infrastructure/Persistence/TacomandaDbContext.cs](../backend/src/Tacomanda.Infrastructure/Persistence/TacomandaDbContext.cs) | Configurar el modelo EF Core; los repositorios son quienes consultan y guardan con este contexto. |
| [backend/src/Tacomanda.Infrastructure/Seed/DatosDePrueba.cs](../backend/src/Tacomanda.Infrastructure/Seed/DatosDePrueba.cs) | Construir los datos iniciales y delegar consultas/guardado a IDatosDePruebaRepository. |
| [backend/src/Tacomanda.Infrastructure/Seed/IDatosDePruebaRepository.cs](../backend/src/Tacomanda.Infrastructure/Seed/IDatosDePruebaRepository.cs) | Contrato de existencia y persistencia del conjunto de datos de prueba. |
| [backend/src/Tacomanda.Infrastructure/Seguridad/JwtSettings.cs](../backend/src/Tacomanda.Infrastructure/Seguridad/JwtSettings.cs) | Mantener configuración JWT y clave efímera encapsulada de esta instancia de prueba. |
| [backend/src/Tacomanda.Infrastructure/Seguridad/JwtTokenService.cs](../backend/src/Tacomanda.Infrastructure/Seguridad/JwtTokenService.cs) | Generar y firmar JWT con identidad, rol y vencimiento. |
| [backend/src/Tacomanda.Infrastructure/Seguridad/Pbkdf2PasswordHasher.cs](../backend/src/Tacomanda.Infrastructure/Seguridad/Pbkdf2PasswordHasher.cs) | Implementar codificación/verificación PBKDF2 mediante interfaces separadas. |
| [backend/src/Tacomanda.Infrastructure/Tacomanda.Infrastructure.csproj](../backend/src/Tacomanda.Infrastructure/Tacomanda.Infrastructure.csproj) | Declarar referencias y dependencias del proyecto Tacomanda.Infrastructure. |

## frontend

| Archivo | Función |
|---|---|
| [frontend/angular.json](../frontend/angular.json) | Configurar compilación, servidor local y cambio de environment por entorno. |
| [frontend/package-lock.json](../frontend/package-lock.json) | Fijar el árbol reproducible de dependencias Angular usado por npm ci. |
| [frontend/package.json](../frontend/package.json) | Declarar dependencias Angular y comandos de ejecución/compilación. |
| [frontend/src/app/app.component.ts](../frontend/src/app/app.component.ts) | Hospedar el router-outlet raíz. |
| [frontend/src/app/app.config.ts](../frontend/src/app/app.config.ts) | Registrar router, HTTP, interceptores y detección de cambios. |
| [frontend/src/app/app.routes.ts](../frontend/src/app/app.routes.ts) | Declarar rutas a login y crear comanda con guard de mesero. |
| [frontend/src/app/core/api/AuthApiClient.ts](../frontend/src/app/core/api/AuthApiClient.ts) | Enviar POST /api/auth/login. |
| [frontend/src/app/core/api/ComandasApiClient.ts](../frontend/src/app/core/api/ComandasApiClient.ts) | Enviar POST /api/comandas. |
| [frontend/src/app/core/api/MesasApiClient.ts](../frontend/src/app/core/api/MesasApiClient.ts) | Enviar GET /api/mesas y recibir DTOs. |
| [frontend/src/app/core/api/PlatillosApiClient.ts](../frontend/src/app/core/api/PlatillosApiClient.ts) | Enviar GET /api/platillos y recibir DTOs. |
| [frontend/src/app/core/http/auth.interceptor.ts](../frontend/src/app/core/http/auth.interceptor.ts) | Adjuntar JWT vigente únicamente a peticiones dirigidas a esta API. |
| [frontend/src/app/core/http/registro-http.interceptor.ts](../frontend/src/app/core/http/registro-http.interceptor.ts) | Registrar estados y fallos HTTP con funciones nombradas. |
| [frontend/src/app/core/modelos/ComandaDto.ts](../frontend/src/app/core/modelos/ComandaDto.ts) | Contrato TypeScript de la respuesta de comanda. |
| [frontend/src/app/core/modelos/CrearComandaRequest.ts](../frontend/src/app/core/modelos/CrearComandaRequest.ts) | Contrato TypeScript de mesa y detalles enviados. |
| [frontend/src/app/core/modelos/DetalleComandaInput.ts](../frontend/src/app/core/modelos/DetalleComandaInput.ts) | Contrato TypeScript del detalle enviado. |
| [frontend/src/app/core/modelos/MesaDto.ts](../frontend/src/app/core/modelos/MesaDto.ts) | Contrato TypeScript de mesa disponible/ocupada. |
| [frontend/src/app/core/modelos/PlatilloDto.ts](../frontend/src/app/core/modelos/PlatilloDto.ts) | Contrato TypeScript del catálogo. |
| [frontend/src/app/core/modelos/Sesion.ts](../frontend/src/app/core/modelos/Sesion.ts) | Contrato TypeScript de datos y token de sesión. |
| [frontend/src/app/core/sesion/CerrarSesionFacade.ts](../frontend/src/app/core/sesion/CerrarSesionFacade.ts) | Coordinar limpieza de sesión y navegación al login. |
| [frontend/src/app/core/sesion/SessionStore.ts](../frontend/src/app/core/sesion/SessionStore.ts) | Encapsular sesión, persistencia en sessionStorage y expiración. |
| [frontend/src/app/core/sesion/mesero.guard.ts](../frontend/src/app/core/sesion/mesero.guard.ts) | Proteger navegación frontend por sesión vigente y rol; la API valida nuevamente. |
| [frontend/src/app/features/crear-comanda/CrearComandaComponent.ts](../frontend/src/app/features/crear-comanda/CrearComandaComponent.ts) | Seleccionar mesa, platillos y cantidades. |
| [frontend/src/app/features/crear-comanda/CrearComandaFacade.ts](../frontend/src/app/features/crear-comanda/CrearComandaFacade.ts) | Preparar la comanda y enviarla. |
| [frontend/src/app/features/crear-comanda/CrearComandaViewModel.ts](../frontend/src/app/features/crear-comanda/CrearComandaViewModel.ts) | Mantener carrito, mesa seleccionada y total. |
| [frontend/src/app/features/crear-comanda/LineaCarrito.ts](../frontend/src/app/features/crear-comanda/LineaCarrito.ts) | Representar una línea inmutable del carrito visual. |
| [frontend/src/app/features/crear-comanda/crear-comanda.component.css](../frontend/src/app/features/crear-comanda/crear-comanda.component.css) | Estilos de la pantalla de captura. |
| [frontend/src/app/features/crear-comanda/crear-comanda.component.html](../frontend/src/app/features/crear-comanda/crear-comanda.component.html) | Dibujar catálogo, carrito, mesa y estados; enlazar eventos y ViewModel. |
| [frontend/src/app/features/inicio-sesion/InicioSesionComponent.ts](../frontend/src/app/features/inicio-sesion/InicioSesionComponent.ts) | Capturar usuario y contraseña; mostrar errores y sesión iniciada. |
| [frontend/src/app/features/inicio-sesion/InicioSesionFacade.ts](../frontend/src/app/features/inicio-sesion/InicioSesionFacade.ts) | Validar datos visuales, llamar al cliente y guardar la sesión. |
| [frontend/src/app/features/inicio-sesion/InicioSesionViewModel.ts](../frontend/src/app/features/inicio-sesion/InicioSesionViewModel.ts) | Mantener usuario, contraseña, loading y mensajes. |
| [frontend/src/app/features/inicio-sesion/inicio-sesion.component.css](../frontend/src/app/features/inicio-sesion/inicio-sesion.component.css) | Estilos de la pantalla de inicio de sesión. |
| [frontend/src/app/features/inicio-sesion/inicio-sesion.component.html](../frontend/src/app/features/inicio-sesion/inicio-sesion.component.html) | Dibujar y capturar usuario/contraseña y mensajes. |
| [frontend/src/environments/environment.prod.ts](../frontend/src/environments/environment.prod.ts) | Configurar API relativa para producción. |
| [frontend/src/environments/environment.ts](../frontend/src/environments/environment.ts) | Configurar API local para desarrollo. |
| [frontend/src/index.html](../frontend/src/index.html) | Documento HTML raíz que hospeda app-root. |
| [frontend/src/main.ts](../frontend/src/main.ts) | Inicializar Angular y registrar fallos de arranque con función nombrada. |
| [frontend/src/styles.css](../frontend/src/styles.css) | Estilos generales compartidos. |
| [frontend/tsconfig.app.json](../frontend/tsconfig.app.json) | Configurar los archivos de entrada TypeScript de la aplicación. |
| [frontend/tsconfig.json](../frontend/tsconfig.json) | Configurar TypeScript/Angular estricto y rootDir explícito. |

## docs

| Archivo | Función |
|---|---|
| [docs/ESTADO_DE_TARJETAS.md](../docs/ESTADO_DE_TARJETAS.md) | Distinguir casos implementados, dependencias y discrepancias entre los PDF. |
| [docs/FLUJO.md](../docs/FLUJO.md) | Explicar recorrido completo de login y crear comanda. |
| [docs/INVENTARIO_ARCHIVOS.md](../docs/INVENTARIO_ARCHIVOS.md) | Inventario de cada archivo del paquete y su función. |
| [docs/MAPA_CRC.md](../docs/MAPA_CRC.md) | Relacionar las tarjetas 01/02 con nombres exactos de archivos y responsabilidades. |
| [docs/VERIFICACION.md](../docs/VERIFICACION.md) | Resultados de compilación y comprobaciones HTTP. |
| [docs/referencias/Cobrar_Comanda_Mesero.pdf](../docs/referencias/Cobrar_Comanda_Mesero.pdf) | Referencia específica de cobro recibida; no implementada en el alcance parcial. |
| [docs/referencias/TACOMANDA_TARJETAS_SRC.pdf](../docs/referencias/TACOMANDA_TARJETAS_SRC.pdf) | Fuente CRC de los once flujos; referencia de nombres y responsabilidades. |

## scripts

| Archivo | Función |
|---|---|
| [scripts/verificar-api.mjs](../scripts/verificar-api.mjs) | Ejecutar 23 comprobaciones HTTP reales contra la API de prueba. |
| [scripts/verificar-arquitectura.mjs](../scripts/verificar-arquitectura.mjs) | Verificar comandos planos, controllers delgados, orden validator/handler y acceso a datos exclusivo de repositories. |

## raiz

| Archivo | Función |
|---|---|
| [.editorconfig](../.editorconfig) | Convenciones de indentación, codificación y saltos de línea. |
| [.gitignore](../.gitignore) | Excluir dependencias, resultados de compilación, cachés y configuración local. |
| [README.md](../README.md) | Alcance, requisitos, instrucciones de ejecución y cuentas de prueba. |
| [backend/src/Tacomanda.Application/Validacion/ValidationBehavior.cs](../backend/src/Tacomanda.Application/Validacion/ValidationBehavior.cs) | Ejecutar validators antes de los handlers de MediatR. |
| [backend/src/Tacomanda.Application/Respuestas/ComandaMappingProfile.cs](../backend/src/Tacomanda.Application/Respuestas/ComandaMappingProfile.cs) | Configurar el mapeo AutoMapper de entidades a respuestas. |

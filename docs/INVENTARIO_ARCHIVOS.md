# Inventario de archivos de TacoManda

Rutas relativas a la raíz. Para el recorrido de un caso de uso consulta [MAPA_CRC.md](MAPA_CRC.md) y [FLUJO.md](FLUJO.md).

## backend

| Archivo | Responsabilidad |
|---|---|
| [`backend/Directory.Build.props`](../backend/Directory.Build.props) | Configurar compilación y dependencias. |
| [`backend/Tacomanda.sln`](../backend/Tacomanda.sln) | Configurar compilación y dependencias. |
| [`backend/src/Tacomanda.Api/Configuration/ApiBehaviorConfiguration.cs`](../backend/src/Tacomanda.Api/Configuration/ApiBehaviorConfiguration.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Api/Configuration/CorsConfiguration.cs`](../backend/src/Tacomanda.Api/Configuration/CorsConfiguration.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Api/Configuration/JwtBearerConfiguration.cs`](../backend/src/Tacomanda.Api/Configuration/JwtBearerConfiguration.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Api/Contracts/AltaEmpleadoRequest.cs`](../backend/src/Tacomanda.Api/Contracts/AltaEmpleadoRequest.cs) | Definir la forma del contrato HTTP. |
| [`backend/src/Tacomanda.Api/Contracts/CambiarEstadoComandaRequest.cs`](../backend/src/Tacomanda.Api/Contracts/CambiarEstadoComandaRequest.cs) | Definir la forma del contrato HTTP. |
| [`backend/src/Tacomanda.Api/Contracts/CobrarComandaRequest.cs`](../backend/src/Tacomanda.Api/Contracts/CobrarComandaRequest.cs) | Definir la forma del contrato HTTP. |
| [`backend/src/Tacomanda.Api/Contracts/CrearComandaRequest.cs`](../backend/src/Tacomanda.Api/Contracts/CrearComandaRequest.cs) | Definir la forma del contrato HTTP. |
| [`backend/src/Tacomanda.Api/Contracts/EditarComandaRequest.cs`](../backend/src/Tacomanda.Api/Contracts/EditarComandaRequest.cs) | Definir la forma del contrato HTTP. |
| [`backend/src/Tacomanda.Api/Contracts/ErrorResponse.cs`](../backend/src/Tacomanda.Api/Contracts/ErrorResponse.cs) | Definir la forma del contrato HTTP. |
| [`backend/src/Tacomanda.Api/Contracts/IniciarSesionRequest.cs`](../backend/src/Tacomanda.Api/Contracts/IniciarSesionRequest.cs) | Definir la forma del contrato HTTP. |
| [`backend/src/Tacomanda.Api/Contracts/PlatilloRequest.cs`](../backend/src/Tacomanda.Api/Contracts/PlatilloRequest.cs) | Definir la forma del contrato HTTP. |
| [`backend/src/Tacomanda.Api/Contracts/RegistrarCierreCajaRequest.cs`](../backend/src/Tacomanda.Api/Contracts/RegistrarCierreCajaRequest.cs) | Definir la forma del contrato HTTP. |
| [`backend/src/Tacomanda.Api/Contracts/RegistrarRetroalimentacionRequest.cs`](../backend/src/Tacomanda.Api/Contracts/RegistrarRetroalimentacionRequest.cs) | Definir la forma del contrato HTTP. |
| [`backend/src/Tacomanda.Api/Controllers/AuthController.cs`](../backend/src/Tacomanda.Api/Controllers/AuthController.cs) | Recibir HTTP, enviar solicitud a MediatR y responder. |
| [`backend/src/Tacomanda.Api/Controllers/CierreCajaController.cs`](../backend/src/Tacomanda.Api/Controllers/CierreCajaController.cs) | Recibir HTTP, enviar solicitud a MediatR y responder. |
| [`backend/src/Tacomanda.Api/Controllers/CobrosController.cs`](../backend/src/Tacomanda.Api/Controllers/CobrosController.cs) | Recibir HTTP, enviar solicitud a MediatR y responder. |
| [`backend/src/Tacomanda.Api/Controllers/ComandasController.cs`](../backend/src/Tacomanda.Api/Controllers/ComandasController.cs) | Recibir HTTP, enviar solicitud a MediatR y responder. |
| [`backend/src/Tacomanda.Api/Controllers/EmpleadosController.cs`](../backend/src/Tacomanda.Api/Controllers/EmpleadosController.cs) | Recibir HTTP, enviar solicitud a MediatR y responder. |
| [`backend/src/Tacomanda.Api/Controllers/MesasController.cs`](../backend/src/Tacomanda.Api/Controllers/MesasController.cs) | Recibir HTTP, enviar solicitud a MediatR y responder. |
| [`backend/src/Tacomanda.Api/Controllers/PlatillosController.cs`](../backend/src/Tacomanda.Api/Controllers/PlatillosController.cs) | Recibir HTTP, enviar solicitud a MediatR y responder. |
| [`backend/src/Tacomanda.Api/Controllers/RetroalimentacionController.cs`](../backend/src/Tacomanda.Api/Controllers/RetroalimentacionController.cs) | Recibir HTTP, enviar solicitud a MediatR y responder. |
| [`backend/src/Tacomanda.Api/Mapping/CrearComandaCommandFactory.cs`](../backend/src/Tacomanda.Api/Mapping/CrearComandaCommandFactory.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Api/Mapping/ICrearComandaCommandFactory.cs`](../backend/src/Tacomanda.Api/Mapping/ICrearComandaCommandFactory.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Api/Middleware/ExceptionMiddleware.cs`](../backend/src/Tacomanda.Api/Middleware/ExceptionMiddleware.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Api/Middleware/RegistroHttpMiddleware.cs`](../backend/src/Tacomanda.Api/Middleware/RegistroHttpMiddleware.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Api/Middleware/StatusCodeResponder.cs`](../backend/src/Tacomanda.Api/Middleware/StatusCodeResponder.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Api/Program.cs`](../backend/src/Tacomanda.Api/Program.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Api/Properties/launchSettings.json`](../backend/src/Tacomanda.Api/Properties/launchSettings.json) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Api/Seguridad/UsuarioActual.cs`](../backend/src/Tacomanda.Api/Seguridad/UsuarioActual.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Api/Tacomanda.Api.csproj`](../backend/src/Tacomanda.Api/Tacomanda.Api.csproj) | Configurar compilación y dependencias. |
| [`backend/src/Tacomanda.Api/appsettings.Development.example.json`](../backend/src/Tacomanda.Api/appsettings.Development.example.json) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Api/appsettings.json`](../backend/src/Tacomanda.Api/appsettings.json) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Application/AltaEmpleado/AltaEmpleadoCommand.cs`](../backend/src/Tacomanda.Application/AltaEmpleado/AltaEmpleadoCommand.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/AltaEmpleado/AltaEmpleadoHandler.cs`](../backend/src/Tacomanda.Application/AltaEmpleado/AltaEmpleadoHandler.cs) | Coordinar un caso de uso mediante interfaces y entidades. |
| [`backend/src/Tacomanda.Application/AltaEmpleado/AltaEmpleadoValidator.cs`](../backend/src/Tacomanda.Application/AltaEmpleado/AltaEmpleadoValidator.cs) | Validar los datos de entrada antes del Handler. |
| [`backend/src/Tacomanda.Application/AltaEmpleado/EmpleadoDto.cs`](../backend/src/Tacomanda.Application/AltaEmpleado/EmpleadoDto.cs) | Transportar datos entre capas. |
| [`backend/src/Tacomanda.Application/CambiarEstadoComanda/CambiarEstadoComandaCommand.cs`](../backend/src/Tacomanda.Application/CambiarEstadoComanda/CambiarEstadoComandaCommand.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/CambiarEstadoComanda/CambiarEstadoComandaHandler.cs`](../backend/src/Tacomanda.Application/CambiarEstadoComanda/CambiarEstadoComandaHandler.cs) | Coordinar un caso de uso mediante interfaces y entidades. |
| [`backend/src/Tacomanda.Application/CambiarEstadoComanda/CambiarEstadoComandaValidator.cs`](../backend/src/Tacomanda.Application/CambiarEstadoComanda/CambiarEstadoComandaValidator.cs) | Validar los datos de entrada antes del Handler. |
| [`backend/src/Tacomanda.Application/CobrarComanda/CobrarComandaCommand.cs`](../backend/src/Tacomanda.Application/CobrarComanda/CobrarComandaCommand.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/CobrarComanda/CobrarComandaHandler.cs`](../backend/src/Tacomanda.Application/CobrarComanda/CobrarComandaHandler.cs) | Coordinar un caso de uso mediante interfaces y entidades. |
| [`backend/src/Tacomanda.Application/CobrarComanda/CobrarComandaValidator.cs`](../backend/src/Tacomanda.Application/CobrarComanda/CobrarComandaValidator.cs) | Validar los datos de entrada antes del Handler. |
| [`backend/src/Tacomanda.Application/CobrarComanda/SelectorPoliticaPago.cs`](../backend/src/Tacomanda.Application/CobrarComanda/SelectorPoliticaPago.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Application/ConsultarCaja/ConsultarCajaQuery.cs`](../backend/src/Tacomanda.Application/ConsultarCaja/ConsultarCajaQuery.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/ConsultarCaja/ConsultarCajaQueryHandler.cs`](../backend/src/Tacomanda.Application/ConsultarCaja/ConsultarCajaQueryHandler.cs) | Coordinar una lectura mediante Reader y devolver DTO. |
| [`backend/src/Tacomanda.Application/ConsultarCaja/IResumenCajaReader.cs`](../backend/src/Tacomanda.Application/ConsultarCaja/IResumenCajaReader.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Application/ConsultarCaja/ResumenCajaDto.cs`](../backend/src/Tacomanda.Application/ConsultarCaja/ResumenCajaDto.cs) | Transportar datos entre capas. |
| [`backend/src/Tacomanda.Application/ConsultarComandas/ConsultarComandaQuery.cs`](../backend/src/Tacomanda.Application/ConsultarComandas/ConsultarComandaQuery.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/ConsultarComandas/ConsultarComandaQueryHandler.cs`](../backend/src/Tacomanda.Application/ConsultarComandas/ConsultarComandaQueryHandler.cs) | Coordinar una lectura mediante Reader y devolver DTO. |
| [`backend/src/Tacomanda.Application/ConsultarComandas/ConsultarComandasQuery.cs`](../backend/src/Tacomanda.Application/ConsultarComandas/ConsultarComandasQuery.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/ConsultarComandas/ConsultarComandasQueryHandler.cs`](../backend/src/Tacomanda.Application/ConsultarComandas/ConsultarComandasQueryHandler.cs) | Coordinar una lectura mediante Reader y devolver DTO. |
| [`backend/src/Tacomanda.Application/ConsultarMesas/ConsultarMesasQuery.cs`](../backend/src/Tacomanda.Application/ConsultarMesas/ConsultarMesasQuery.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/ConsultarMesas/ConsultarMesasQueryHandler.cs`](../backend/src/Tacomanda.Application/ConsultarMesas/ConsultarMesasQueryHandler.cs) | Coordinar una lectura mediante Reader y devolver DTO. |
| [`backend/src/Tacomanda.Application/ConsultarMesas/IMesaReader.cs`](../backend/src/Tacomanda.Application/ConsultarMesas/IMesaReader.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Application/ConsultarMesas/MesaDto.cs`](../backend/src/Tacomanda.Application/ConsultarMesas/MesaDto.cs) | Transportar datos entre capas. |
| [`backend/src/Tacomanda.Application/ConsultarPlatillo/ConsultarPlatilloQuery.cs`](../backend/src/Tacomanda.Application/ConsultarPlatillo/ConsultarPlatilloQuery.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/ConsultarPlatillo/ConsultarPlatilloQueryHandler.cs`](../backend/src/Tacomanda.Application/ConsultarPlatillo/ConsultarPlatilloQueryHandler.cs) | Coordinar una lectura mediante Reader y devolver DTO. |
| [`backend/src/Tacomanda.Application/ConsultarPlatillo/IConsultarPlatilloQueryHandler.cs`](../backend/src/Tacomanda.Application/ConsultarPlatillo/IConsultarPlatilloQueryHandler.cs) | Coordinar una lectura mediante Reader y devolver DTO. |
| [`backend/src/Tacomanda.Application/ConsultarPlatillo/IPlatilloReader.cs`](../backend/src/Tacomanda.Application/ConsultarPlatillo/IPlatilloReader.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Application/ConsultarPlatillo/PlatilloDto.cs`](../backend/src/Tacomanda.Application/ConsultarPlatillo/PlatilloDto.cs) | Transportar datos entre capas. |
| [`backend/src/Tacomanda.Application/ConsultarUsuarios/ConsultarUsuariosQuery.cs`](../backend/src/Tacomanda.Application/ConsultarUsuarios/ConsultarUsuariosQuery.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/ConsultarUsuarios/ConsultarUsuariosQueryHandler.cs`](../backend/src/Tacomanda.Application/ConsultarUsuarios/ConsultarUsuariosQueryHandler.cs) | Coordinar una lectura mediante Reader y devolver DTO. |
| [`backend/src/Tacomanda.Application/ConsultarUsuarios/IEmpleadoReader.cs`](../backend/src/Tacomanda.Application/ConsultarUsuarios/IEmpleadoReader.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Application/ConsultarUsuarios/UsuarioDisponibleDto.cs`](../backend/src/Tacomanda.Application/ConsultarUsuarios/UsuarioDisponibleDto.cs) | Transportar datos entre capas. |
| [`backend/src/Tacomanda.Application/CrearComanda/CrearComandaCommand.cs`](../backend/src/Tacomanda.Application/CrearComanda/CrearComandaCommand.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/CrearComanda/CrearComandaHandler.cs`](../backend/src/Tacomanda.Application/CrearComanda/CrearComandaHandler.cs) | Coordinar un caso de uso mediante interfaces y entidades. |
| [`backend/src/Tacomanda.Application/CrearComanda/CrearComandaValidator.cs`](../backend/src/Tacomanda.Application/CrearComanda/CrearComandaValidator.cs) | Validar los datos de entrada antes del Handler. |
| [`backend/src/Tacomanda.Application/CrearComanda/DetalleComandaInput.cs`](../backend/src/Tacomanda.Application/CrearComanda/DetalleComandaInput.cs) | Transportar datos entre capas. |
| [`backend/src/Tacomanda.Application/CrearPlatillo/CrearPlatilloCommand.cs`](../backend/src/Tacomanda.Application/CrearPlatillo/CrearPlatilloCommand.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/CrearPlatillo/CrearPlatilloHandler.cs`](../backend/src/Tacomanda.Application/CrearPlatillo/CrearPlatilloHandler.cs) | Coordinar un caso de uso mediante interfaces y entidades. |
| [`backend/src/Tacomanda.Application/CrearPlatillo/CrearPlatilloValidator.cs`](../backend/src/Tacomanda.Application/CrearPlatillo/CrearPlatilloValidator.cs) | Validar los datos de entrada antes del Handler. |
| [`backend/src/Tacomanda.Application/DependencyInjection.cs`](../backend/src/Tacomanda.Application/DependencyInjection.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Application/EditarComanda/EditarComandaCommand.cs`](../backend/src/Tacomanda.Application/EditarComanda/EditarComandaCommand.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/EditarComanda/EditarComandaHandler.cs`](../backend/src/Tacomanda.Application/EditarComanda/EditarComandaHandler.cs) | Coordinar un caso de uso mediante interfaces y entidades. |
| [`backend/src/Tacomanda.Application/EditarComanda/EditarComandaValidator.cs`](../backend/src/Tacomanda.Application/EditarComanda/EditarComandaValidator.cs) | Validar los datos de entrada antes del Handler. |
| [`backend/src/Tacomanda.Application/EditarPlatillo/EditarPlatilloCommand.cs`](../backend/src/Tacomanda.Application/EditarPlatillo/EditarPlatilloCommand.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/EditarPlatillo/EditarPlatilloHandler.cs`](../backend/src/Tacomanda.Application/EditarPlatillo/EditarPlatilloHandler.cs) | Coordinar un caso de uso mediante interfaces y entidades. |
| [`backend/src/Tacomanda.Application/EditarPlatillo/EditarPlatilloValidator.cs`](../backend/src/Tacomanda.Application/EditarPlatillo/EditarPlatilloValidator.cs) | Validar los datos de entrada antes del Handler. |
| [`backend/src/Tacomanda.Application/EliminarPlatillo/EliminarPlatilloCommand.cs`](../backend/src/Tacomanda.Application/EliminarPlatillo/EliminarPlatilloCommand.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/EliminarPlatillo/EliminarPlatilloHandler.cs`](../backend/src/Tacomanda.Application/EliminarPlatillo/EliminarPlatilloHandler.cs) | Coordinar un caso de uso mediante interfaces y entidades. |
| [`backend/src/Tacomanda.Application/EliminarPlatillo/EliminarPlatilloValidator.cs`](../backend/src/Tacomanda.Application/EliminarPlatillo/EliminarPlatilloValidator.cs) | Validar los datos de entrada antes del Handler. |
| [`backend/src/Tacomanda.Application/InicioSesion/IniciarSesionCommand.cs`](../backend/src/Tacomanda.Application/InicioSesion/IniciarSesionCommand.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/InicioSesion/IniciarSesionHandler.cs`](../backend/src/Tacomanda.Application/InicioSesion/IniciarSesionHandler.cs) | Coordinar un caso de uso mediante interfaces y entidades. |
| [`backend/src/Tacomanda.Application/InicioSesion/IniciarSesionValidator.cs`](../backend/src/Tacomanda.Application/InicioSesion/IniciarSesionValidator.cs) | Validar los datos de entrada antes del Handler. |
| [`backend/src/Tacomanda.Application/InicioSesion/SesionDto.cs`](../backend/src/Tacomanda.Application/InicioSesion/SesionDto.cs) | Transportar datos entre capas. |
| [`backend/src/Tacomanda.Application/RegistrarCierreCaja/CierreCajaDto.cs`](../backend/src/Tacomanda.Application/RegistrarCierreCaja/CierreCajaDto.cs) | Transportar datos entre capas. |
| [`backend/src/Tacomanda.Application/RegistrarCierreCaja/RegistrarCierreCajaCommand.cs`](../backend/src/Tacomanda.Application/RegistrarCierreCaja/RegistrarCierreCajaCommand.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/RegistrarCierreCaja/RegistrarCierreCajaHandler.cs`](../backend/src/Tacomanda.Application/RegistrarCierreCaja/RegistrarCierreCajaHandler.cs) | Coordinar un caso de uso mediante interfaces y entidades. |
| [`backend/src/Tacomanda.Application/RegistrarCierreCaja/RegistrarCierreCajaValidator.cs`](../backend/src/Tacomanda.Application/RegistrarCierreCaja/RegistrarCierreCajaValidator.cs) | Validar los datos de entrada antes del Handler. |
| [`backend/src/Tacomanda.Application/RegistrarRetroalimentacion/RegistrarRetroalimentacionCommand.cs`](../backend/src/Tacomanda.Application/RegistrarRetroalimentacion/RegistrarRetroalimentacionCommand.cs) | Transportar la intención sin persistir información. |
| [`backend/src/Tacomanda.Application/RegistrarRetroalimentacion/RegistrarRetroalimentacionHandler.cs`](../backend/src/Tacomanda.Application/RegistrarRetroalimentacion/RegistrarRetroalimentacionHandler.cs) | Coordinar un caso de uso mediante interfaces y entidades. |
| [`backend/src/Tacomanda.Application/RegistrarRetroalimentacion/RegistrarRetroalimentacionValidator.cs`](../backend/src/Tacomanda.Application/RegistrarRetroalimentacion/RegistrarRetroalimentacionValidator.cs) | Validar los datos de entrada antes del Handler. |
| [`backend/src/Tacomanda.Application/RegistrarRetroalimentacion/RetroalimentacionDto.cs`](../backend/src/Tacomanda.Application/RegistrarRetroalimentacion/RetroalimentacionDto.cs) | Transportar datos entre capas. |
| [`backend/src/Tacomanda.Application/Respuestas/ComandaDto.cs`](../backend/src/Tacomanda.Application/Respuestas/ComandaDto.cs) | Transportar datos entre capas. |
| [`backend/src/Tacomanda.Application/Respuestas/ComandaMappingProfile.cs`](../backend/src/Tacomanda.Application/Respuestas/ComandaMappingProfile.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Application/Respuestas/DetalleComandaDto.cs`](../backend/src/Tacomanda.Application/Respuestas/DetalleComandaDto.cs) | Transportar datos entre capas. |
| [`backend/src/Tacomanda.Application/Seguridad/IPasswordEncoder.cs`](../backend/src/Tacomanda.Application/Seguridad/IPasswordEncoder.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Application/Seguridad/IPasswordHasher.cs`](../backend/src/Tacomanda.Application/Seguridad/IPasswordHasher.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Application/Seguridad/ITokenService.cs`](../backend/src/Tacomanda.Application/Seguridad/ITokenService.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Application/Seguridad/IUsuarioActual.cs`](../backend/src/Tacomanda.Application/Seguridad/IUsuarioActual.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Application/Seguridad/TokenDto.cs`](../backend/src/Tacomanda.Application/Seguridad/TokenDto.cs) | Transportar datos entre capas. |
| [`backend/src/Tacomanda.Application/Tacomanda.Application.csproj`](../backend/src/Tacomanda.Application/Tacomanda.Application.csproj) | Configurar compilación y dependencias. |
| [`backend/src/Tacomanda.Application/Validacion/IValidator.cs`](../backend/src/Tacomanda.Application/Validacion/IValidator.cs) | Validar los datos de entrada antes del Handler. |
| [`backend/src/Tacomanda.Application/Validacion/ValidacionException.cs`](../backend/src/Tacomanda.Application/Validacion/ValidacionException.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Application/Validacion/ValidationBehavior.cs`](../backend/src/Tacomanda.Application/Validacion/ValidationBehavior.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Domain/Cierres/CierreCaja.cs`](../backend/src/Tacomanda.Domain/Cierres/CierreCaja.cs) | Encapsular estado e invariantes del negocio. |
| [`backend/src/Tacomanda.Domain/Comandas/Comanda.cs`](../backend/src/Tacomanda.Domain/Comandas/Comanda.cs) | Encapsular estado e invariantes del negocio. |
| [`backend/src/Tacomanda.Domain/Comandas/DetalleComanda.cs`](../backend/src/Tacomanda.Domain/Comandas/DetalleComanda.cs) | Encapsular estado e invariantes del negocio. |
| [`backend/src/Tacomanda.Domain/Comandas/OrderStatus.cs`](../backend/src/Tacomanda.Domain/Comandas/OrderStatus.cs) | Encapsular estado e invariantes del negocio. |
| [`backend/src/Tacomanda.Domain/Empleados/Empleado.cs`](../backend/src/Tacomanda.Domain/Empleados/Empleado.cs) | Encapsular estado e invariantes del negocio. |
| [`backend/src/Tacomanda.Domain/Empleados/EmployeeRole.cs`](../backend/src/Tacomanda.Domain/Empleados/EmployeeRole.cs) | Encapsular estado e invariantes del negocio. |
| [`backend/src/Tacomanda.Domain/Excepciones/ReglaDeNegocioException.cs`](../backend/src/Tacomanda.Domain/Excepciones/ReglaDeNegocioException.cs) | Encapsular estado e invariantes del negocio. |
| [`backend/src/Tacomanda.Domain/Interfaces/IAltaEmpleadoRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/IAltaEmpleadoRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/ICierreCajaRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/ICierreCajaRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/ICierresLecturaRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/ICierresLecturaRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IComandaReader.cs`](../backend/src/Tacomanda.Domain/Interfaces/IComandaReader.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IComandaRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/IComandaRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IComandasLecturaRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/IComandasLecturaRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IEmpleadoRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/IEmpleadoRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IEmpleadosLecturaRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/IEmpleadosLecturaRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IMesaRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/IMesaRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IMesasLecturaRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/IMesasLecturaRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IMeseroReader.cs`](../backend/src/Tacomanda.Domain/Interfaces/IMeseroReader.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IMeseroRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/IMeseroRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IPagoRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/IPagoRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IPlatilloRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/IPlatilloRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IPlatillosEscrituraRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/IPlatillosEscrituraRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IPlatillosLecturaRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/IPlatillosLecturaRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IRetroalimentacionRepository.cs`](../backend/src/Tacomanda.Domain/Interfaces/IRetroalimentacionRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Interfaces/IUnidadDeTrabajo.cs`](../backend/src/Tacomanda.Domain/Interfaces/IUnidadDeTrabajo.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Mesas/Mesa.cs`](../backend/src/Tacomanda.Domain/Mesas/Mesa.cs) | Encapsular estado e invariantes del negocio. |
| [`backend/src/Tacomanda.Domain/Pagos/IPoliticaDePago.cs`](../backend/src/Tacomanda.Domain/Pagos/IPoliticaDePago.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Domain/Pagos/Pago.cs`](../backend/src/Tacomanda.Domain/Pagos/Pago.cs) | Encapsular estado e invariantes del negocio. |
| [`backend/src/Tacomanda.Domain/Pagos/PoliticaEfectivo.cs`](../backend/src/Tacomanda.Domain/Pagos/PoliticaEfectivo.cs) | Encapsular estado e invariantes del negocio. |
| [`backend/src/Tacomanda.Domain/Pagos/PoliticaTarjeta.cs`](../backend/src/Tacomanda.Domain/Pagos/PoliticaTarjeta.cs) | Encapsular estado e invariantes del negocio. |
| [`backend/src/Tacomanda.Domain/Platillos/Platillo.cs`](../backend/src/Tacomanda.Domain/Platillos/Platillo.cs) | Encapsular estado e invariantes del negocio. |
| [`backend/src/Tacomanda.Domain/Retroalimentacion/Retroalimentacion.cs`](../backend/src/Tacomanda.Domain/Retroalimentacion/Retroalimentacion.cs) | Encapsular estado e invariantes del negocio. |
| [`backend/src/Tacomanda.Domain/Tacomanda.Domain.csproj`](../backend/src/Tacomanda.Domain/Tacomanda.Domain.csproj) | Configurar compilación y dependencias. |
| [`backend/src/Tacomanda.Infrastructure/DependencyInjection.cs`](../backend/src/Tacomanda.Infrastructure/DependencyInjection.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Configurations/CierreCajaConfiguration.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Configurations/CierreCajaConfiguration.cs) | Mapear entidad y columnas al esquema MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Configurations/ComandaConfiguration.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Configurations/ComandaConfiguration.cs) | Mapear entidad y columnas al esquema MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Configurations/DetalleComandaConfiguration.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Configurations/DetalleComandaConfiguration.cs) | Mapear entidad y columnas al esquema MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Configurations/EmpleadoConfiguration.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Configurations/EmpleadoConfiguration.cs) | Mapear entidad y columnas al esquema MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Configurations/MesaConfiguration.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Configurations/MesaConfiguration.cs) | Mapear entidad y columnas al esquema MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Configurations/PagoConfiguration.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Configurations/PagoConfiguration.cs) | Mapear entidad y columnas al esquema MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Configurations/PlatilloConfiguration.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Configurations/PlatilloConfiguration.cs) | Mapear entidad y columnas al esquema MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Configurations/RetroalimentacionConfiguration.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Configurations/RetroalimentacionConfiguration.cs) | Mapear entidad y columnas al esquema MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Readers/ComandaReader.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Readers/ComandaReader.cs) | Delegar consultas al repositorio de lectura. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Readers/EmpleadoReader.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Readers/EmpleadoReader.cs) | Delegar consultas al repositorio de lectura. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Readers/MesaReader.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Readers/MesaReader.cs) | Delegar consultas al repositorio de lectura. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Readers/MeseroReader.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Readers/MeseroReader.cs) | Delegar consultas al repositorio de lectura. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Readers/PlatilloReader.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Readers/PlatilloReader.cs) | Delegar consultas al repositorio de lectura. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Readers/ResumenCajaReader.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Readers/ResumenCajaReader.cs) | Delegar consultas al repositorio de lectura. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/CierreCajaRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/CierreCajaRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/CierresLecturaRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/CierresLecturaRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/ComandaRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/ComandaRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/ComandasLecturaRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/ComandasLecturaRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/DatosDePruebaRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/DatosDePruebaRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/EmpleadoRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/EmpleadoRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/EmpleadosLecturaRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/EmpleadosLecturaRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/MesaRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/MesaRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/MesasLecturaRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/MesasLecturaRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/MeseroRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/MeseroRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/PagoRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/PagoRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/PlatilloRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/PlatilloRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/PlatillosLecturaRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/PlatillosLecturaRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/RetroalimentacionRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/RetroalimentacionRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/Repositories/UnidadDeTrabajoRepository.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/Repositories/UnidadDeTrabajoRepository.cs) | Consultar o guardar mediante EF Core y MySQL. |
| [`backend/src/Tacomanda.Infrastructure/Persistence/TacomandaDbContext.cs`](../backend/src/Tacomanda.Infrastructure/Persistence/TacomandaDbContext.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Infrastructure/Seed/BootstrapAdmin.cs`](../backend/src/Tacomanda.Infrastructure/Seed/BootstrapAdmin.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Infrastructure/Seed/DatosDePrueba.cs`](../backend/src/Tacomanda.Infrastructure/Seed/DatosDePrueba.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Infrastructure/Seed/IDatosDePruebaRepository.cs`](../backend/src/Tacomanda.Infrastructure/Seed/IDatosDePruebaRepository.cs) | Definir un contrato pequeño para una operación. |
| [`backend/src/Tacomanda.Infrastructure/Seguridad/JwtSettings.cs`](../backend/src/Tacomanda.Infrastructure/Seguridad/JwtSettings.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Infrastructure/Seguridad/JwtTokenService.cs`](../backend/src/Tacomanda.Infrastructure/Seguridad/JwtTokenService.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Infrastructure/Seguridad/Pbkdf2PasswordHasher.cs`](../backend/src/Tacomanda.Infrastructure/Seguridad/Pbkdf2PasswordHasher.cs) | Configurar o apoyar este módulo. |
| [`backend/src/Tacomanda.Infrastructure/Tacomanda.Infrastructure.csproj`](../backend/src/Tacomanda.Infrastructure/Tacomanda.Infrastructure.csproj) | Configurar compilación y dependencias. |

## frontend

| Archivo | Responsabilidad |
|---|---|
| [`frontend/angular.json`](../frontend/angular.json) | Configurar o apoyar este módulo. |
| [`frontend/package-lock.json`](../frontend/package-lock.json) | Configurar o apoyar este módulo. |
| [`frontend/package.json`](../frontend/package.json) | Configurar o apoyar este módulo. |
| [`frontend/src/app/app.component.ts`](../frontend/src/app/app.component.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/app.config.ts`](../frontend/src/app/app.config.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/app.routes.ts`](../frontend/src/app/app.routes.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/core/api/AuthApiClient.ts`](../frontend/src/app/core/api/AuthApiClient.ts) | Comunicarse por HTTP con la API. |
| [`frontend/src/app/core/api/CierreCajaApiClient.ts`](../frontend/src/app/core/api/CierreCajaApiClient.ts) | Comunicarse por HTTP con la API. |
| [`frontend/src/app/core/api/CobrosApiClient.ts`](../frontend/src/app/core/api/CobrosApiClient.ts) | Comunicarse por HTTP con la API. |
| [`frontend/src/app/core/api/ComandasApiClient.ts`](../frontend/src/app/core/api/ComandasApiClient.ts) | Comunicarse por HTTP con la API. |
| [`frontend/src/app/core/api/EmpleadosApiClient.ts`](../frontend/src/app/core/api/EmpleadosApiClient.ts) | Comunicarse por HTTP con la API. |
| [`frontend/src/app/core/api/MesasApiClient.ts`](../frontend/src/app/core/api/MesasApiClient.ts) | Comunicarse por HTTP con la API. |
| [`frontend/src/app/core/api/PlatillosApiClient.ts`](../frontend/src/app/core/api/PlatillosApiClient.ts) | Comunicarse por HTTP con la API. |
| [`frontend/src/app/core/api/RetroalimentacionApiClient.ts`](../frontend/src/app/core/api/RetroalimentacionApiClient.ts) | Comunicarse por HTTP con la API. |
| [`frontend/src/app/core/http/auth.interceptor.ts`](../frontend/src/app/core/http/auth.interceptor.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/core/http/registro-http.interceptor.ts`](../frontend/src/app/core/http/registro-http.interceptor.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/core/modelos/ComandaDto.ts`](../frontend/src/app/core/modelos/ComandaDto.ts) | Transportar datos entre capas. |
| [`frontend/src/app/core/modelos/CrearComandaRequest.ts`](../frontend/src/app/core/modelos/CrearComandaRequest.ts) | Transportar datos entre capas. |
| [`frontend/src/app/core/modelos/DetalleComandaInput.ts`](../frontend/src/app/core/modelos/DetalleComandaInput.ts) | Transportar datos entre capas. |
| [`frontend/src/app/core/modelos/MesaDto.ts`](../frontend/src/app/core/modelos/MesaDto.ts) | Transportar datos entre capas. |
| [`frontend/src/app/core/modelos/PlatilloDto.ts`](../frontend/src/app/core/modelos/PlatilloDto.ts) | Transportar datos entre capas. |
| [`frontend/src/app/core/modelos/Sesion.ts`](../frontend/src/app/core/modelos/Sesion.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/core/sesion/CerrarSesionFacade.ts`](../frontend/src/app/core/sesion/CerrarSesionFacade.ts) | Coordinar acciones y carga de la pantalla. |
| [`frontend/src/app/core/sesion/SessionStore.ts`](../frontend/src/app/core/sesion/SessionStore.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/core/sesion/administrador.guard.ts`](../frontend/src/app/core/sesion/administrador.guard.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/core/sesion/cajero.guard.ts`](../frontend/src/app/core/sesion/cajero.guard.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/core/sesion/cierre.guard.ts`](../frontend/src/app/core/sesion/cierre.guard.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/core/sesion/cobro.guard.ts`](../frontend/src/app/core/sesion/cobro.guard.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/core/sesion/cocinero.guard.ts`](../frontend/src/app/core/sesion/cocinero.guard.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/core/sesion/mesero.guard.ts`](../frontend/src/app/core/sesion/mesero.guard.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/core/sesion/sesion.guard.ts`](../frontend/src/app/core/sesion/sesion.guard.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/features/administracion/AdministracionComponent.ts`](../frontend/src/app/features/administracion/AdministracionComponent.ts) | Dibujar pantalla y capturar eventos. |
| [`frontend/src/app/features/administracion/AdministracionFacade.ts`](../frontend/src/app/features/administracion/AdministracionFacade.ts) | Coordinar acciones y carga de la pantalla. |
| [`frontend/src/app/features/administracion/AdministracionViewModel.ts`](../frontend/src/app/features/administracion/AdministracionViewModel.ts) | Mantener el estado de la pantalla. |
| [`frontend/src/app/features/administracion/administracion.component.css`](../frontend/src/app/features/administracion/administracion.component.css) | Aplicar estilos y adaptación de pantalla. |
| [`frontend/src/app/features/administracion/administracion.component.html`](../frontend/src/app/features/administracion/administracion.component.html) | Mostrar vista y enlazar controles. |
| [`frontend/src/app/features/caja/CajaComponent.ts`](../frontend/src/app/features/caja/CajaComponent.ts) | Dibujar pantalla y capturar eventos. |
| [`frontend/src/app/features/caja/CajaFacade.ts`](../frontend/src/app/features/caja/CajaFacade.ts) | Coordinar acciones y carga de la pantalla. |
| [`frontend/src/app/features/caja/CajaViewModel.ts`](../frontend/src/app/features/caja/CajaViewModel.ts) | Mantener el estado de la pantalla. |
| [`frontend/src/app/features/caja/caja.component.css`](../frontend/src/app/features/caja/caja.component.css) | Aplicar estilos y adaptación de pantalla. |
| [`frontend/src/app/features/caja/caja.component.html`](../frontend/src/app/features/caja/caja.component.html) | Mostrar vista y enlazar controles. |
| [`frontend/src/app/features/cierre-caja/CierreCajaComponent.ts`](../frontend/src/app/features/cierre-caja/CierreCajaComponent.ts) | Dibujar pantalla y capturar eventos. |
| [`frontend/src/app/features/cierre-caja/CierreCajaFacade.ts`](../frontend/src/app/features/cierre-caja/CierreCajaFacade.ts) | Coordinar acciones y carga de la pantalla. |
| [`frontend/src/app/features/cierre-caja/CierreCajaViewModel.ts`](../frontend/src/app/features/cierre-caja/CierreCajaViewModel.ts) | Mantener el estado de la pantalla. |
| [`frontend/src/app/features/cierre-caja/cierre-caja.component.css`](../frontend/src/app/features/cierre-caja/cierre-caja.component.css) | Aplicar estilos y adaptación de pantalla. |
| [`frontend/src/app/features/cierre-caja/cierre-caja.component.html`](../frontend/src/app/features/cierre-caja/cierre-caja.component.html) | Mostrar vista y enlazar controles. |
| [`frontend/src/app/features/cobrar-comanda/CobrarComandaMeseroComponent.ts`](../frontend/src/app/features/cobrar-comanda/CobrarComandaMeseroComponent.ts) | Dibujar pantalla y capturar eventos. |
| [`frontend/src/app/features/cobrar-comanda/CobrarComandaMeseroFacade.ts`](../frontend/src/app/features/cobrar-comanda/CobrarComandaMeseroFacade.ts) | Coordinar acciones y carga de la pantalla. |
| [`frontend/src/app/features/cobrar-comanda/CobrarComandaMeseroViewModel.ts`](../frontend/src/app/features/cobrar-comanda/CobrarComandaMeseroViewModel.ts) | Mantener el estado de la pantalla. |
| [`frontend/src/app/features/cocina/CambiarEstadoComandaComponent.ts`](../frontend/src/app/features/cocina/CambiarEstadoComandaComponent.ts) | Dibujar pantalla y capturar eventos. |
| [`frontend/src/app/features/cocina/CambiarEstadoComandaFacade.ts`](../frontend/src/app/features/cocina/CambiarEstadoComandaFacade.ts) | Coordinar acciones y carga de la pantalla. |
| [`frontend/src/app/features/cocina/CambiarEstadoComandaViewModel.ts`](../frontend/src/app/features/cocina/CambiarEstadoComandaViewModel.ts) | Mantener el estado de la pantalla. |
| [`frontend/src/app/features/cocina/cambiar-estado-comanda.component.css`](../frontend/src/app/features/cocina/cambiar-estado-comanda.component.css) | Aplicar estilos y adaptación de pantalla. |
| [`frontend/src/app/features/cocina/cambiar-estado-comanda.component.html`](../frontend/src/app/features/cocina/cambiar-estado-comanda.component.html) | Mostrar vista y enlazar controles. |
| [`frontend/src/app/features/consultar-comandas/ConsultarComandasComponent.ts`](../frontend/src/app/features/consultar-comandas/ConsultarComandasComponent.ts) | Dibujar pantalla y capturar eventos. |
| [`frontend/src/app/features/consultar-comandas/ConsultarComandasFacade.ts`](../frontend/src/app/features/consultar-comandas/ConsultarComandasFacade.ts) | Coordinar acciones y carga de la pantalla. |
| [`frontend/src/app/features/consultar-comandas/ConsultarComandasViewModel.ts`](../frontend/src/app/features/consultar-comandas/ConsultarComandasViewModel.ts) | Mantener el estado de la pantalla. |
| [`frontend/src/app/features/consultar-comandas/consultar-comandas.component.css`](../frontend/src/app/features/consultar-comandas/consultar-comandas.component.css) | Aplicar estilos y adaptación de pantalla. |
| [`frontend/src/app/features/consultar-comandas/consultar-comandas.component.html`](../frontend/src/app/features/consultar-comandas/consultar-comandas.component.html) | Mostrar vista y enlazar controles. |
| [`frontend/src/app/features/crear-comanda/CrearComandaComponent.ts`](../frontend/src/app/features/crear-comanda/CrearComandaComponent.ts) | Dibujar pantalla y capturar eventos. |
| [`frontend/src/app/features/crear-comanda/CrearComandaFacade.ts`](../frontend/src/app/features/crear-comanda/CrearComandaFacade.ts) | Coordinar acciones y carga de la pantalla. |
| [`frontend/src/app/features/crear-comanda/CrearComandaViewModel.ts`](../frontend/src/app/features/crear-comanda/CrearComandaViewModel.ts) | Mantener el estado de la pantalla. |
| [`frontend/src/app/features/crear-comanda/LineaCarrito.ts`](../frontend/src/app/features/crear-comanda/LineaCarrito.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/app/features/crear-comanda/crear-comanda.component.css`](../frontend/src/app/features/crear-comanda/crear-comanda.component.css) | Aplicar estilos y adaptación de pantalla. |
| [`frontend/src/app/features/crear-comanda/crear-comanda.component.html`](../frontend/src/app/features/crear-comanda/crear-comanda.component.html) | Mostrar vista y enlazar controles. |
| [`frontend/src/app/features/editar-comanda/EditarComandaComponent.ts`](../frontend/src/app/features/editar-comanda/EditarComandaComponent.ts) | Dibujar pantalla y capturar eventos. |
| [`frontend/src/app/features/editar-comanda/EditarComandaFacade.ts`](../frontend/src/app/features/editar-comanda/EditarComandaFacade.ts) | Coordinar acciones y carga de la pantalla. |
| [`frontend/src/app/features/editar-comanda/EditarComandaViewModel.ts`](../frontend/src/app/features/editar-comanda/EditarComandaViewModel.ts) | Mantener el estado de la pantalla. |
| [`frontend/src/app/features/inicio-sesion/InicioSesionComponent.ts`](../frontend/src/app/features/inicio-sesion/InicioSesionComponent.ts) | Definir un contrato pequeño para una operación. |
| [`frontend/src/app/features/inicio-sesion/InicioSesionFacade.ts`](../frontend/src/app/features/inicio-sesion/InicioSesionFacade.ts) | Definir un contrato pequeño para una operación. |
| [`frontend/src/app/features/inicio-sesion/InicioSesionViewModel.ts`](../frontend/src/app/features/inicio-sesion/InicioSesionViewModel.ts) | Definir un contrato pequeño para una operación. |
| [`frontend/src/app/features/inicio-sesion/inicio-sesion.component.css`](../frontend/src/app/features/inicio-sesion/inicio-sesion.component.css) | Aplicar estilos y adaptación de pantalla. |
| [`frontend/src/app/features/inicio-sesion/inicio-sesion.component.html`](../frontend/src/app/features/inicio-sesion/inicio-sesion.component.html) | Mostrar vista y enlazar controles. |
| [`frontend/src/app/features/retroalimentacion/RetroalimentacionComponent.ts`](../frontend/src/app/features/retroalimentacion/RetroalimentacionComponent.ts) | Dibujar pantalla y capturar eventos. |
| [`frontend/src/app/features/retroalimentacion/RetroalimentacionFacade.ts`](../frontend/src/app/features/retroalimentacion/RetroalimentacionFacade.ts) | Coordinar acciones y carga de la pantalla. |
| [`frontend/src/app/features/retroalimentacion/RetroalimentacionViewModel.ts`](../frontend/src/app/features/retroalimentacion/RetroalimentacionViewModel.ts) | Mantener el estado de la pantalla. |
| [`frontend/src/app/features/retroalimentacion/retroalimentacion.component.css`](../frontend/src/app/features/retroalimentacion/retroalimentacion.component.css) | Aplicar estilos y adaptación de pantalla. |
| [`frontend/src/app/features/retroalimentacion/retroalimentacion.component.html`](../frontend/src/app/features/retroalimentacion/retroalimentacion.component.html) | Mostrar vista y enlazar controles. |
| [`frontend/src/app/features/ticket/TicketComponent.ts`](../frontend/src/app/features/ticket/TicketComponent.ts) | Dibujar pantalla y capturar eventos. |
| [`frontend/src/app/features/ticket/TicketFacade.ts`](../frontend/src/app/features/ticket/TicketFacade.ts) | Coordinar acciones y carga de la pantalla. |
| [`frontend/src/app/features/ticket/TicketViewModel.ts`](../frontend/src/app/features/ticket/TicketViewModel.ts) | Mantener el estado de la pantalla. |
| [`frontend/src/app/features/ticket/ticket.component.css`](../frontend/src/app/features/ticket/ticket.component.css) | Aplicar estilos y adaptación de pantalla. |
| [`frontend/src/app/features/ticket/ticket.component.html`](../frontend/src/app/features/ticket/ticket.component.html) | Mostrar vista y enlazar controles. |
| [`frontend/src/environments/environment.prod.ts`](../frontend/src/environments/environment.prod.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/environments/environment.ts`](../frontend/src/environments/environment.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/index.html`](../frontend/src/index.html) | Mostrar vista y enlazar controles. |
| [`frontend/src/main.ts`](../frontend/src/main.ts) | Configurar o apoyar este módulo. |
| [`frontend/src/styles.css`](../frontend/src/styles.css) | Aplicar estilos y adaptación de pantalla. |
| [`frontend/tsconfig.app.json`](../frontend/tsconfig.app.json) | Configurar o apoyar este módulo. |
| [`frontend/tsconfig.json`](../frontend/tsconfig.json) | Configurar o apoyar este módulo. |

## database

| Archivo | Responsabilidad |
|---|---|
| [`database/schema.sql`](../database/schema.sql) | Crear tablas, relaciones y datos iniciales; borra la base previa. |

## scripts

| Archivo | Responsabilidad |
|---|---|
| [`scripts/verificar-api.mjs`](../scripts/verificar-api.mjs) | Verificar estructura o comportamiento. |
| [`scripts/verificar-arquitectura.mjs`](../scripts/verificar-arquitectura.mjs) | Verificar estructura o comportamiento. |

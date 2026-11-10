# Parcial ampliada: cuatro historias nuevas

Los flujos originales de login y crear comanda permanecen. La consulta GET de platillos existente alimenta el catálogo y la pantalla administrativa.

| Historia | Pantalla Angular | API | Application | Domain / Infrastructure |
| --- | --- | --- | --- | --- |
| Alta de mesero o cajero | `AdministracionComponent`, `AdministracionViewModel`, `AdministracionFacade`, `EmpleadosApiClient` | `EmpleadosController`, `AltaEmpleadoRequest` | `AltaEmpleadoCommand`, `AltaEmpleadoValidator`, `AltaEmpleadoHandler`, `EmpleadoDto` | `IEmpleadoRepository` comprueba duplicados, `IAltaEmpleadoRepository` agrega, `EmpleadoRepository` usa EF, `IUnidadDeTrabajo` confirma |
| Crear platillo | Mismos Component/ViewModel/Facade, `PlatillosApiClient` | `PlatillosController`, `PlatilloRequest` | `CrearPlatilloCommand`, `CrearPlatilloValidator`, `CrearPlatilloHandler` | `IPlatillosEscrituraRepository`, `PlatilloRepository`, unidad de trabajo |
| Editar platillo | Mismos Component/ViewModel/Facade/ApiClient | `PlatillosController`, `PlatilloRequest` | `EditarPlatilloCommand`, `EditarPlatilloValidator`, `EditarPlatilloHandler` | `IPlatilloRepository` carga la entidad, `Platillo.Editar` protege reglas, unidad de trabajo persiste |
| Eliminar platillo | Mismos Component/ViewModel/Facade/ApiClient | `PlatillosController` | `EliminarPlatilloCommand`, `EliminarPlatilloValidator`, `EliminarPlatilloHandler` | `IPlatilloRepository`, `Platillo.Desactivar`, unidad de trabajo |

MediatR ejecuta los validadores mediante `ValidationBehavior` antes de cada Handler. Los Controllers traducen el resultado a HTTP y `ExceptionMiddleware` convierte excepciones a errores con mensaje público genérico. `POST /api/empleados`, `POST /api/platillos`, `PUT /api/platillos/{id}` y `DELETE /api/platillos/{id}` exigen JWT de `Administrador`. GET `/api/platillos` permite `Mesero` y `Administrador`. Las consultas existentes ocultan los platillos desactivados. Eliminar es baja lógica para preservar los nombres y precios históricos de las comandas.

La base de prueba sigue siendo SQLite en memoria y se reinicia al detener la API. Para SQL Server: instalar el proveedor EF Core de SQL Server, configurar la cadena de conexión fuera del repositorio, cambiar `BaseDeDatosMemoria`/`AddDbContext`, generar y aplicar migraciones, y revisar el seed, índices y consultas SQL específicas de SQLite. La API y los Handlers no necesitan conocer el proveedor. Las contraseñas se codifican con PBKDF2 antes de persistir; el DTO de alta nunca contiene contraseña ni hash.

Prueba manual: iniciar API y Angular; entrar como `admin / admin123`; crear un platillo, editarlo y desactivarlo; registrar un usuario Mesero y entrar con él; comprobar que los platillos desactivados ya no aparecen. Reiniciar la API devuelve los datos de prueba originales.

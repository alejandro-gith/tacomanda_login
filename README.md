<<<<<<< HEAD
# Tacomanda — entrega parcial CRC y mediadores propios

Implementa **01. Inicio de sesión** y **02. Crear comanda**, con las clases nombradas como en `docs/referencias/TACOMANDA_TARJETAS_SRC.pdf`.
Incluye las consultas de catálogo y mesas necesarias para capturar una comanda. No incluye pantallas de alta de empleados, administración, cobro, consulta de comandas ni edición.

## Primero: revisar nombres y responsabilidades

- [MAPA_CRC.md](docs/MAPA_CRC.md): cada tarjeta implementada, su archivo y su responsabilidad.
- [INVENTARIO_ARCHIVOS.md](docs/INVENTARIO_ARCHIVOS.md): todos los archivos, incluidos los de soporte técnico.
- [FLUJO.md](docs/FLUJO.md): recorrido de ida y regreso, JWT, Mediator y validación.
- [ESTADO_DE_TARJETAS.md](docs/ESTADO_DE_TARJETAS.md): alcance y diferencias entre los PDF recibidos.
- [VERIFICACION.md](docs/VERIFICACION.md): comprobaciones realizadas.

## Ejecutar

Requisitos: SDK .NET 10 y Node.js 24. Se conserva Angular 22 y su package-lock.json de la entrega previa.
Las versiones NuGet se fijan en los archivos .csproj.

En una terminal:
=======
# TacoManda · Login y toma de comanda

Versión académica reducida que contiene únicamente dos flujos completos:

1. Inicio de sesión del mesero con contraseña, PBKDF2 y JWT.
2. Consulta de mesas/platillos y registro de una comanda.

La solución conserva CQRS, principios SOLID y la separación:

```text
Vista → Facade → API Controller → Command/Query → Validator
      → Handler → Repository → InMemoryDatabase → Domain
```

## Requisitos

- .NET SDK 10
- Node.js 24 LTS con npm

## Ejecutar

Terminal 1:
>>>>>>> 4c695f795a46a9ec3b62cb63a997060b28afe20a

```powershell
cd backend
dotnet restore Tacomanda.sln
dotnet build Tacomanda.sln
dotnet run --project src/Tacomanda.Api
```

<<<<<<< HEAD
En otra terminal:
=======
Terminal 2:
>>>>>>> 4c695f795a46a9ec3b62cb63a997060b28afe20a

```powershell
cd frontend
npm ci
npm start
```

<<<<<<< HEAD
Abrir http://localhost:4200. API en http://localhost:8080.

Cuenta para esta entrega: **mesero / mesero123**.
El login recibe `usuario` y `password`, como indica su tarjeta. El diseño mantiene los estilos de las pantallas anteriores, con campo de usuario en lugar de selección de empleado.
Existe `cajero / cajero123` para comprobar que la API rechaza crear comandas con otro rol. La pantalla de esta entrega admite el rol Mesero.

## Persistencia de prueba

Se usa **SQLite en memoria con EF Core** y datos semilla en `DatosDePrueba.cs`.
Esto permite un `TacomandaDbContext` real y una transacción al crear la comanda y ocupar la mesa.
Al detener la API se pierden los cambios. Al reiniciar también cambia la clave JWT de desarrollo: hay que iniciar sesión de nuevo.

El repositorio agrega la comanda y sus detalles al contexto. El handler pide confirmar a `IUnidadDeTrabajo`; UnidadDeTrabajoRepository guarda la comanda y el estado de la mesa en la misma transacción.
La versión de la mesa es un token de concurrencia para evitar que dos peticiones creen comandas simultáneas para una misma mesa.

Para usar otra base de datos hay que cambiar el proveedor y la configuración de Infrastructure, adaptar su consulta SQL y crear migraciones. Las reglas y controllers no dependen del proveedor.

## Convenciones

Una clase principal por archivo; nombres de tarjetas preservados; métodos y funciones con nombre; sin lambdas ni callbacks anónimos en el código fuente propio.
`ICrearComandaMediator` e `IIniciarSesionMediator` son interfaces propias con una sola operación. Sus implementaciones llaman explícitamente al validator y después al handler. No hay paquete MediatR, IRequest ni pipeline externo. Los commands y queries solo transportan datos; el DTO de respuesta aparece en la firma del handler y del mediador.
Los handlers devuelven DTOs y la API decide el código HTTP. Un DTO no consulta la base de datos: representa los datos de respuesta.
Las consultas y guardados de la aplicación están exclusivamente en archivos Repository. Los readers delegan en repositorios de lectura; la siembra y la confirmación transaccional también usan repositorios. DbContext y BaseDeDatosMemoria son el soporte técnico para configurar el modelo y mantener la conexión.
La lectura del JWT está en `UsuarioActual.cs`; el controller no usa `User`, `Claims`, `Guid.Parse`, repositorios ni validadores.

Los límites concretos, no detallados por las tarjetas, se establecen así: contraseña 8–128, usuario hasta 80 caracteres; cantidad 1–99; observación hasta 200; comanda 1–100 detalles. Se documentan como decisiones de implementación, no como texto original de las tarjetas.
La contraseña no se recorta ni se registra. El precio y el total se obtienen en el servidor.

## Respuestas

- Login correcto: 200.
- Comanda creada: 201.
- Entrada inválida: 400.
- Credenciales o token inválidos: 401.
- Rol no autorizado: 403.
- Mesa inexistente: 404.
- Conflicto de reglas o concurrencia: 409.
- Fallo inesperado: 500.

Al usuario se devuelve `Error en el sistema.` y un identificador de trazabilidad; el detalle queda en consola.
Los estados HTTP se conservan. Nunca se convierte un error en un 200.

## Comprobación reproducible

Con una API recién iniciada, desde la raíz:

```powershell
node scripts/verificar-arquitectura.mjs
node scripts/verificar-api.mjs
```

La comprobación crea comandas en la base de pruebas. Reinicia la API para repetirla desde cero.
=======
Abrir `http://localhost:4200`. La API usa `http://localhost:8080`.

## Cuenta de prueba

| Usuario | Contraseña | Rol |
|---|---|---|
| mesero | mesero123 | Mesero |

El selector muestra “Mesero local”. El frontend envía el GUID del empleado y la contraseña; nunca usa el nombre visible como identificador.

## Base de prueba

`InMemoryDatabase` carga al mesero, seis platillos y ocho mesas. Las comandas creadas y las mesas ocupadas permanecen mientras la API siga ejecutándose; al reiniciarla se restauran los datos iniciales.

## Endpoints incluidos

| Método | Ruta | Uso |
|---|---|---|
| GET | `/api/auth/users` | Obtener el mesero disponible |
| POST | `/api/auth/login` | Validar credenciales y generar JWT |
| GET | `/api/dishes` | Obtener platillos activos |
| GET | `/api/tables` | Obtener mesas y disponibilidad |
| POST | `/api/orders` | Registrar una nueva comanda |
| GET | `/api/health` | Verificar que la API está activa |

## Validación

- `LoginCommandValidator`: revisa GUID, presencia y longitud de contraseña.
- `CreateOrderCommandValidator`: revisa IDs, número de partidas, cantidades y longitud de notas.
- `LoginCommandHandler`: consulta al empleado y verifica contraseña/estado.
- `CreateOrderCommandHandler`: comprueba mesa, mesero y platillos usando repositorios.
- `Domain`: calcula subtotales/total y evita ocupar dos veces la mesa.

Todos los errores conservan su código HTTP. La interfaz solo muestra `Error en el sistema.` y el detalle técnico se registra en la consola.

Los casos CQRS se organizan en `Tacomanda.Application/Auth`, `Dishes` y `Orders`, con un archivo por command/query, validator y handler. Consulta `docs/arquitectura.md`, `docs/api.md` y `docs/responsabilidades-solid.md`.
>>>>>>> 4c695f795a46a9ec3b62cb63a997060b28afe20a

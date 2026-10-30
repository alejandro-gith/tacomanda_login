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

```powershell
cd backend
dotnet restore Tacomanda.sln
dotnet build Tacomanda.sln
dotnet run --project src/Tacomanda.Api
```

Terminal 2:

```powershell
cd frontend
npm ci
npm start
```

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

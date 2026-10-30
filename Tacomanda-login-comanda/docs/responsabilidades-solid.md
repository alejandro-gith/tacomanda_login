# Responsabilidades, validaciones y patrones

| Componente                            | Responsabilidad única                                  | Validación o regla                                                 | SOLID   | Patrón                           |
| ------------------------------------- | ------------------------------------------------------ | ------------------------------------------------------------------ | ------- | -------------------------------- |
| Vista Angular (`*.component.html`)    | Dibujar y capturar interacción.                        | UX: required, maxlength, deshabilitar mientras carga.              | S       | View / Observer                  |
| Componente Angular (`*.component.ts`) | Conectar ciclo de vida con la facade.                  | Ninguna regla de negocio.                                          | S, D    | Adapter                          |
| Facade (`*.facade.ts`)                | Sanear entradas y coordinar el estado de una pantalla. | Trim, estado de carga y comprobaciones visuales inmediatas.        | S, D    | Facade / Presentation Controller |
| API Controller                        | Traducir HTTP a command/query y DTO a HTTP.            | Model binding, claims y códigos HTTP; no reglas de negocio.        | S, D    | Controller / Adapter             |
| Command / Query                       | Transportar una intención inmutable.                   | Ninguna: solo propiedades.                                         | O       | Command / DTO                    |
| Validator                             | Verificar formato sin consultar repositorios.          | Vacíos, longitudes, rangos, GUID y valores permitidos.             | S, O, I | Validator / Specification        |
| Handler                               | Orquestar un caso de uso.                              | Reglas semánticas: existencia, rol, estado, duplicados y permisos. | S, D    | Command Handler / Use Case       |
| Domain                                | Representar el negocio y proteger invariantes.         | Cantidad válida, cálculo del total y mesa disponible.              | S, O    | Entity / Aggregate               |
| Repository (Domain)                   | Definir el contrato necesario para persistencia.       | Ninguna regla HTTP/SQL.                                            | I, D    | Repository                       |
| Infrastructure                        | Implementar contratos y resolver detalles técnicos.    | Concurrencia, duplicados técnicos, hashing y almacenamiento.       | L, D    | Repository / Adapter             |

## Regla rápida

- Si se puede decidir mirando solamente el command, corresponde al validator.
- Si necesita consultar datos reales, corresponde al handler.
- Si la regla debe cumplirse sin importar desde qué caso de uso se invoque, pertenece al Domain.
- Si depende de HTTP, SQL, memoria, JWT o criptografía, pertenece a API/Infrastructure.

## Validators incluidos

- `Auth/Commands/LoginCommandValidator.cs`
- `Orders/Commands/CreateOrderCommandValidator.cs`

Todos implementan `IValidator<T>` y se registran en `Tacomanda.Api/Program.cs`.

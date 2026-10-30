# Arquitectura del apartado

## Dependencias

```text
Tacomanda.Domain ← Tacomanda.Application ← Tacomanda.Infrastructure
                           ↑                         ↑
                           └──── Tacomanda.Api ─────┘

Angular → HTTP/JWT → Tacomanda.Api
```

- `Domain`: entidades, reglas e interfaces de repositorio. No referencia otra capa.
- `Application`: contratos CQRS y casos de uso separados por feature, intención y tipo.
- `Infrastructure`: base en memoria, hashing PBKDF2 e implementaciones de servicios.
- `Api`: controllers, JWT, composición de dependencias y middleware HTTP.
- `Angular`: componentes, facades, servicios, modelos, guards e interceptors.

## Archivos CQRS

### Autenticación

| Tipo | Archivo | Para qué existe |
|---|---|---|
| Query | `Auth/Queries/GetAvailableUsersQuery.cs` | Solicita los meseros disponibles para el selector. |
| Query handler | `Auth/Queries/GetAvailableUsersHandler.cs` | Consulta el repositorio y prepara la lista de usuarios. |
| Command | `Auth/Commands/LoginCommand.cs` | Transporta el ID y la contraseña recibidos. |
| Validator | `Auth/Commands/LoginCommandValidator.cs` | Valida la forma de los datos de inicio de sesión. |
| Command handler | `Auth/Commands/LoginCommandHandler.cs` | Busca al empleado, verifica contraseña y solicita el token. |

### Toma de comanda

| Tipo | Archivo | Para qué existe |
|---|---|---|
| Query | `Dishes/Queries/ListDishesQuery.cs` | Pide el catálogo de platillos. |
| Query handler | `Dishes/Queries/ListDishesHandler.cs` | Lee platillos y los convierte a DTO. |
| Query | `Orders/Queries/ListTablesQuery.cs` | Pide la disponibilidad de mesas. |
| Query handler | `Orders/Queries/ListTablesHandler.cs` | Lee las mesas y prepara sus estados para la API. |
| Command | `Orders/Commands/CreateOrderCommand.cs` | Transporta mesa, mesero y partidas solicitadas. |
| Validator | `Orders/Commands/CreateOrderCommandValidator.cs` | Revisa IDs, cantidades y notas sin consultar la base. |
| Command handler | `Orders/Commands/CreateOrderCommandHandler.cs` | Consulta repositorios, aplica reglas y guarda la comanda. |

Los contratos compartidos tienen archivos propios en `Common/Contracts`, `Common/Handlers`, `Common/Validation` y `Common/Security`. Los DTO están junto a la feature que los usa.

## Flujo de login

```text
login.component.html
→ login.component.ts
→ login.facade.ts
→ AuthService / ApiService
→ AuthController
→ LoginCommand
→ Auth/Commands/LoginCommandValidator.cs
→ LoginCommandHandler
→ IEmployeeRepository
→ InMemoryDatabase + Pbkdf2PasswordService
→ JwtTokenService
→ SessionStore
→ /mesero
```

El validator revisa únicamente el formato. El handler consulta al empleado y aplica las reglas semánticas. La contraseña se compara mediante PBKDF2 y el controller nunca la valida directamente.

## Flujo de toma de comanda

```text
waiter.component.html
→ waiter.component.ts
→ waiter.facade.ts
→ ApiService
→ OrdersController
→ CreateOrderCommand
→ Orders/Commands/CreateOrderCommandValidator.cs
→ CreateOrderCommandHandler
→ ITableRepository + IDishRepository + IEmployeeRepository + IOrderRepository
→ InMemoryDatabase
→ RestaurantTable + Order + OrderItem
→ OrderDto (HTTP 201)
→ WaiterFacade
→ waiter.component.html
```

El validator comprueba IDs, cantidades y longitudes sin consultar almacenamiento. El handler verifica la existencia y estado real de la mesa, el mesero y los platillos. El dominio calcula subtotales y total, además de proteger la ocupación de la mesa.

## Cambio futuro a SQL

Application solo conoce interfaces. Para utilizar SQL se crean implementaciones nuevas de `IEmployeeRepository`, `IDishRepository`, `ITableRepository` e `IOrderRepository` y se cambian sus registros en `Program.cs`; los handlers, controllers y Angular permanecen iguales.

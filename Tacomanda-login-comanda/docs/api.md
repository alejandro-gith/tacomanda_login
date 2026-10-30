# API local · Login y toma de comanda

| Método | Ruta              | Autorización | Command/Query            | Handler                    |
| ------ | ----------------- | ------------ | ------------------------ | -------------------------- |
| GET    | `/api/auth/users` | Público      | `GetAvailableUsersQuery` | `GetAvailableUsersHandler` |
| POST   | `/api/auth/login` | Público      | `LoginCommand`           | `LoginCommandHandler`             |
| GET    | `/api/dishes`     | JWT Mesero   | `ListDishesQuery`        | `ListDishesHandler`        |
| GET    | `/api/tables`     | JWT Mesero   | `ListTablesQuery`        | `ListTablesHandler`        |
| POST   | `/api/orders`     | JWT Mesero   | `CreateOrderCommand`     | `CreateOrderCommandHandler`       |
| GET    | `/api/health`     | Público      | No aplica                | No aplica                  |

Los endpoints protegidos requieren:

```http
Authorization: Bearer <accessToken>
```

Ejemplo de login:

```json
{
  "employeeId": "10000000-0000-0000-0000-000000000002",
  "password": "mesero123"
}
```

Ejemplo de comanda:

```json
{
  "tableId": "30000000-0000-0000-0000-000000000001",
  "items": [
    {
      "dishId": "20000000-0000-0000-0000-000000000001",
      "quantity": 2,
      "note": "Sin cebolla"
    }
  ]
}
```

Una comanda válida responde con HTTP `201`. Una contraseña incorrecta responde con `401`; entrada mal formada con `400`; recurso inexistente con `404`; mesa ocupada con `409`.

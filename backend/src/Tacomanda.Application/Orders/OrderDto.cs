namespace Tacomanda.Application;

public sealed record OrderItemDto(
    Guid DishId,
    string DishName,
    decimal UnitPrice,
    int Quantity,
    string Note,
    decimal Subtotal);

public sealed record OrderDto(
    Guid Id,
    int Number,
    Guid TableId,
    string TableName,
    string WaiterName,
    string Status,
    DateTimeOffset CreatedAt,
    IReadOnlyList<OrderItemDto> Items,
    decimal Total);

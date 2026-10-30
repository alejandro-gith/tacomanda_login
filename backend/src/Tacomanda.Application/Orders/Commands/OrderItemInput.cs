namespace Tacomanda.Application;

public sealed record OrderItemInput(Guid DishId, int Quantity, string? Note);

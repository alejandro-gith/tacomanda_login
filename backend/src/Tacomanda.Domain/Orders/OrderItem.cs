namespace Tacomanda.Domain;

public sealed record OrderItem(
    Guid DishId,
    string DishName,
    decimal UnitPrice,
    int Quantity,
    string Note)
{
    public decimal Subtotal => decimal.Round(UnitPrice * Quantity, 2);
}

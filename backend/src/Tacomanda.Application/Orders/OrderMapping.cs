using Tacomanda.Domain;

namespace Tacomanda.Application;

public static class OrderMapping
{
    public static OrderDto ToDto(this Order order) => new(
        order.Id,
        order.Number,
        order.TableId,
        order.TableName,
        order.WaiterName,
        "Pendiente",
        order.CreatedAt,
        order.Items.Select(item => new OrderItemDto(
            item.DishId,
            item.DishName,
            item.UnitPrice,
            item.Quantity,
            item.Note,
            item.Subtotal)).ToArray(),
        order.Total);
}

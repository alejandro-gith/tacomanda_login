namespace Tacomanda.Application;

public sealed record CreateOrderCommand(
    Guid TableId,
    Guid WaiterId,
    IReadOnlyList<OrderItemInput> Items) : ICommand<OrderDto>;

namespace Tacomanda.Domain;

public sealed class Order
{
    public Order(
        Guid id,
        int number,
        Guid tableId,
        string tableName,
        Guid waiterId,
        string waiterName,
        IReadOnlyList<OrderItem> items,
        DateTimeOffset createdAt)
    {
        if (items.Count == 0 || items.Any(item => item.Quantity <= 0))
            throw new DomainException("Order details are invalid.");

        Id = id;
        Number = number;
        TableId = tableId;
        TableName = tableName;
        WaiterId = waiterId;
        WaiterName = waiterName;
        Items = items;
        CreatedAt = createdAt;
        Status = OrderStatus.Pending;
    }

    public Guid Id { get; }
    public int Number { get; }
    public Guid TableId { get; }
    public string TableName { get; }
    public Guid WaiterId { get; }
    public string WaiterName { get; }
    public IReadOnlyList<OrderItem> Items { get; }
    public DateTimeOffset CreatedAt { get; }
    public OrderStatus Status { get; private set; }
    public decimal Total => Items.Sum(x => x.Subtotal);
}

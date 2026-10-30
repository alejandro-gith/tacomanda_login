using Tacomanda.Domain;

namespace Tacomanda.Application;

public sealed class CreateOrderCommandHandler(
    IValidator<CreateOrderCommand> validator,
    IOrderRepository orders,
    ITableRepository tables,
    IDishRepository dishes,
    IEmployeeRepository employees)
    : ICommandHandler<CreateOrderCommand, OrderDto>
{
    public async Task<OrderDto> Handle(CreateOrderCommand command, CancellationToken ct)
    {
        validator.Validate(command);

        var table = await tables.FindAsync(command.TableId, ct)
            ?? throw new NotFoundException("Table not found.");
        if (table.Status != TableStatus.Available)
            throw new ConflictException("Table is unavailable.");

        var waiter = await employees.FindAsync(command.WaiterId, ct)
            ?? throw new NotFoundException("Waiter not found.");
        if (waiter.Role != EmployeeRole.Waiter || !waiter.IsActive)
            throw new UnauthorizedAccessException("Employee is not an active waiter.");

        var details = new List<OrderItem>();
        foreach (var input in command.Items)
        {
            var foundDish = await dishes.FindAsync(input.DishId, ct);
            if (foundDish is null || !foundDish.IsActive)
                throw new DomainException("Dish is unavailable.");

            details.Add(new OrderItem(
                foundDish.Id,
                foundDish.Name,
                foundDish.Price,
                input.Quantity,
                input.Note?.Trim() ?? ""));
        }

        var order = new Order(
            Guid.NewGuid(),
            orders.NextNumber(),
            table.Id,
            table.Name,
            waiter.Id,
            waiter.DisplayName,
            details,
            DateTimeOffset.UtcNow);

        table.Occupy();
        await orders.AddAsync(order, ct);
        await tables.UpdateAsync(table, ct);
        return order.ToDto();
    }
}

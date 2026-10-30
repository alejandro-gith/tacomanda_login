namespace Tacomanda.Application;

public sealed class CreateOrderCommandValidator : IValidator<CreateOrderCommand>
{
    public void Validate(CreateOrderCommand command)
    {
        ValidationRules.Require(
            command.TableId != Guid.Empty,
            "Table id is required.");
        ValidationRules.Require(
            command.WaiterId != Guid.Empty,
            "Waiter id is required.");
        var items = command.Items
            ?? throw new RequestValidationException("Order items are required.");
        ValidationRules.Require(
            items.Count is >= 1 and <= 100,
            "Order item count is invalid.");

        foreach (var item in items)
        {
            ValidationRules.Require(
                item.DishId != Guid.Empty,
                "Dish id is required.");
            ValidationRules.Require(
                item.Quantity is >= 1 and <= 99,
                "Order quantity is invalid.");
            ValidationRules.Require(
                (item.Note?.Trim().Length ?? 0) <= 200,
                "Order note is too long.");
        }
    }
}

using Tacomanda.Domain;

namespace Tacomanda.Application;

public sealed class ListDishesHandler(IDishRepository dishes)
    : IQueryHandler<ListDishesQuery, IReadOnlyList<DishDto>>
{
    public async Task<IReadOnlyList<DishDto>> Handle(
        ListDishesQuery query,
        CancellationToken ct)
    {
        var dishList = await dishes.ListAsync(query.ActiveOnly, ct);
        return dishList.Select(dish => new DishDto(
            dish.Id,
            dish.Name,
            dish.Category,
            dish.Description,
            dish.Price,
            dish.Emoji,
            dish.IsActive)).ToArray();
    }
}

namespace Tacomanda.Application;

public sealed record ListDishesQuery(bool ActiveOnly)
    : IQuery<IReadOnlyList<DishDto>>;

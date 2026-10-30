namespace Tacomanda.Application;

public sealed record DishDto(
    Guid Id,
    string Name,
    string Category,
    string Description,
    decimal Price,
    string Emoji,
    bool IsActive);

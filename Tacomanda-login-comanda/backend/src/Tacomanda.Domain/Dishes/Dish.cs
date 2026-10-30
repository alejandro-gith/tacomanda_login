namespace Tacomanda.Domain;

public sealed class Dish
{
    public Dish(
        Guid id,
        string name,
        string category,
        string description,
        decimal price,
        string emoji,
        bool isActive = true)
    {
        Id = id;
        Update(name, category, description, price, emoji);
        IsActive = isActive;
    }

    public Guid Id { get; }
    public string Name { get; private set; } = "";
    public string Category { get; private set; } = "";
    public string Description { get; private set; } = "";
    public decimal Price { get; private set; }
    public string Emoji { get; private set; } = "🌮";
    public bool IsActive { get; private set; }

    public void Update(string name, string category, string? description, decimal price, string? emoji)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Trim().Length > 80)
            throw new DomainException("Dish name is invalid.");
        if (string.IsNullOrWhiteSpace(category) || category.Trim().Length > 50)
            throw new DomainException("Dish category is invalid.");
        if (price <= 0 || price > 100000)
            throw new DomainException("Dish price is invalid.");
        if ((description?.Length ?? 0) > 250)
            throw new DomainException("Dish description is too long.");

        Name = name.Trim();
        Category = category.Trim();
        Description = description?.Trim() ?? "";
        Price = decimal.Round(price, 2);
        Emoji = string.IsNullOrWhiteSpace(emoji) ? "🌮" : emoji.Trim();
    }

    public void Deactivate() => IsActive = false;
}

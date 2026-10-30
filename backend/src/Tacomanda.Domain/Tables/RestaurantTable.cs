namespace Tacomanda.Domain;

public sealed class RestaurantTable
{
    public RestaurantTable(
        Guid id,
        string name,
        TableStatus status = TableStatus.Available)
    {
        Id = id;
        Name = name;
        Status = status;
    }

    public Guid Id { get; }
    public string Name { get; }
    public TableStatus Status { get; private set; }

    public void Occupy()
    {
        if (Status != TableStatus.Available)
            throw new ConflictException("Table is occupied.");

        Status = TableStatus.Occupied;
    }
}

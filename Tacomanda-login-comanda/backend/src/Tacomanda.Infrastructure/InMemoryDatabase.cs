using Tacomanda.Application;
using Tacomanda.Domain;

namespace Tacomanda.Infrastructure;

public sealed class InMemoryDatabase
    : IEmployeeRepository, IDishRepository, ITableRepository, IOrderRepository
{
    private readonly object _gate = new();
    private readonly List<Employee> _employees = [];
    private readonly List<Dish> _dishes = [];
    private readonly List<RestaurantTable> _tables = [];
    private readonly List<Order> _orders = [];
    private int _nextOrder = 1001;

    public InMemoryDatabase(IPasswordService passwords)
    {
        var waiterId = Guid.Parse("10000000-0000-0000-0000-000000000002");
        _employees.Add(new Employee(
            waiterId,
            "mesero",
            "Mesero local",
            EmployeeRole.Waiter,
            passwords.Hash("mesero123")));

        _dishes.AddRange([
            new(
                Guid.Parse("20000000-0000-0000-0000-000000000001"),
                "Taco al pastor",
                "Tacos",
                "Carne al pastor, piña y cebolla",
                18m,
                "🌮"),
            new(
                Guid.Parse("20000000-0000-0000-0000-000000000002"),
                "Taco de bistec",
                "Tacos",
                "Bistec, cilantro y cebolla",
                20m,
                "🥩"),
            new(
                Guid.Parse("20000000-0000-0000-0000-000000000003"),
                "Quesadilla",
                "Antojitos",
                "Tortilla de harina con queso",
                38m,
                "🫓"),
            new(
                Guid.Parse("20000000-0000-0000-0000-000000000004"),
                "Gringa",
                "Antojitos",
                "Pastor, queso y tortilla de harina",
                52m,
                "🧀"),
            new(
                Guid.Parse("20000000-0000-0000-0000-000000000005"),
                "Agua de horchata",
                "Bebidas",
                "Vaso de 500 ml",
                28m,
                "🥤"),
            new(
                Guid.Parse("20000000-0000-0000-0000-000000000006"),
                "Refresco",
                "Bebidas",
                "Botella de 600 ml",
                30m,
                "🧃")
        ]);

        for (var number = 1; number <= 8; number++)
        {
            _tables.Add(new RestaurantTable(
                Guid.Parse($"30000000-0000-0000-0000-{number:D12}"),
                $"Mesa {number}"));
        }
    }

    Task<IReadOnlyList<Employee>> IEmployeeRepository.ListActiveAsync(
        CancellationToken ct)
    {
        lock (_gate)
            return Task.FromResult<IReadOnlyList<Employee>>(
                _employees.Where(employee => employee.IsActive).ToArray());
    }

    Task<Employee?> IEmployeeRepository.FindAsync(
        Guid id,
        CancellationToken ct)
    {
        lock (_gate)
            return Task.FromResult(_employees.FirstOrDefault(employee => employee.Id == id));
    }

    public Task<IReadOnlyList<Dish>> ListAsync(
        bool activeOnly,
        CancellationToken ct)
    {
        lock (_gate)
            return Task.FromResult<IReadOnlyList<Dish>>(
                _dishes
                    .Where(dish => !activeOnly || dish.IsActive)
                    .OrderBy(dish => dish.Category)
                    .ThenBy(dish => dish.Name)
                    .ToArray());
    }

    Task<Dish?> IDishRepository.FindAsync(Guid id, CancellationToken ct)
    {
        lock (_gate)
            return Task.FromResult(_dishes.FirstOrDefault(dish => dish.Id == id));
    }

    public Task<IReadOnlyList<RestaurantTable>> ListAsync(CancellationToken ct)
    {
        lock (_gate)
            return Task.FromResult<IReadOnlyList<RestaurantTable>>(_tables.ToArray());
    }

    Task<RestaurantTable?> ITableRepository.FindAsync(Guid id, CancellationToken ct)
    {
        lock (_gate)
            return Task.FromResult(_tables.FirstOrDefault(table => table.Id == id));
    }

    public Task UpdateAsync(RestaurantTable table, CancellationToken ct) =>
        Task.CompletedTask;

    public Task AddAsync(Order order, CancellationToken ct)
    {
        lock (_gate)
            _orders.Add(order);
        return Task.CompletedTask;
    }

    public int NextNumber()
    {
        lock (_gate)
            return _nextOrder++;
    }
}

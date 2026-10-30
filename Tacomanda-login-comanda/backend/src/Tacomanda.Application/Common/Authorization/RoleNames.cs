namespace Tacomanda.Application;

public static class RoleNames
{
    public const string Waiter = "Mesero";

    public static string From(Tacomanda.Domain.EmployeeRole role) => role switch
    {
        Tacomanda.Domain.EmployeeRole.Waiter => Waiter,
        _ => throw new ArgumentOutOfRangeException(nameof(role))
    };
}

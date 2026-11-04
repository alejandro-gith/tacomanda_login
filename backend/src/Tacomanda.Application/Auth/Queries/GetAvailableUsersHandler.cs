using Tacomanda.Domain;

namespace Tacomanda.Application;

public sealed class GetAvailableUsersHandler(IEmployeeRepository employees)
    : IQueryHandler<GetAvailableUsersQuery, IReadOnlyList<AvailableUserDto>>
{
    public async Task<IReadOnlyList<AvailableUserDto>> Handle(
        GetAvailableUsersQuery query,
        CancellationToken ct)
    {
        var employeesList = await employees.ListActiveAsync(ct);

        return employeesList
            .Select(employee => new AvailableUserDto(
                employee.Id,
                employee.DisplayName,
                RoleNames.From(employee.Role)))
            .ToArray();
    }
}

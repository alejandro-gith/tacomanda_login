namespace Tacomanda.Application;

public sealed record GetAvailableUsersQuery
    : IQuery<IReadOnlyList<AvailableUserDto>>;

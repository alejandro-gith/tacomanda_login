namespace Tacomanda.Application;

public sealed record SessionDto(
    Guid EmployeeId,
    string Username,
    string DisplayName,
    string Role,
    string AccessToken,
    DateTimeOffset ExpiresAt);

namespace Tacomanda.Domain;

public sealed record Employee(
    Guid Id,
    string Username,
    string DisplayName,
    EmployeeRole Role,
    string PasswordHash,
    bool IsActive = true);

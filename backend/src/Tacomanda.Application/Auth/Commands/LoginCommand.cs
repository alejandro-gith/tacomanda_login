namespace Tacomanda.Application;

public sealed record LoginCommand(Guid EmployeeId, string Password)
    : ICommand<SessionDto>;

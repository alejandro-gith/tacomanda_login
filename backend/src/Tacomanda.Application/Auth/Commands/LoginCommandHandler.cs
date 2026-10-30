using Tacomanda.Domain;

namespace Tacomanda.Application;

public sealed class LoginCommandHandler(
    IValidator<LoginCommand> validator,
    IEmployeeRepository employees,
    IPasswordService passwords,
    ITokenService tokens) : ICommandHandler<LoginCommand, SessionDto>
{
    public async Task<SessionDto> Handle(LoginCommand command, CancellationToken ct)
    {
        validator.Validate(command);

        var employee = await employees.FindAsync(command.EmployeeId, ct);
        if (employee is null
            || !employee.IsActive
            || !passwords.Verify(employee.PasswordHash, command.Password))
        {
            throw new UnauthorizedAccessException("Invalid credentials.");
        }

        var role = RoleNames.From(employee.Role);
        var token = tokens.Issue(
            employee.Id,
            employee.Username,
            employee.DisplayName,
            role);

        return new SessionDto(
            employee.Id,
            employee.Username,
            employee.DisplayName,
            role,
            token.Token,
            token.ExpiresAt);
    }
}

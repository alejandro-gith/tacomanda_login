namespace Tacomanda.Application;

public sealed class LoginCommandValidator : IValidator<LoginCommand>
{
    public void Validate(LoginCommand command)
    {
        ValidationRules.Require(
            command.EmployeeId != Guid.Empty,
            "Employee id is required.");
        ValidationRules.Require(
            !string.IsNullOrWhiteSpace(command.Password),
            "Password is required.");
        ValidationRules.Require(
            command.Password.Length is >= 8 and <= 128,
            "Password length is invalid.");
    }
}

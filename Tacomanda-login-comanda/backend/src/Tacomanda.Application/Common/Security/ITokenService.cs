namespace Tacomanda.Application;

public interface ITokenService
{
    TokenResult Issue(
        Guid employeeId,
        string username,
        string displayName,
        string role);
}

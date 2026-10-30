using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tacomanda.Application;

namespace Tacomanda.Api.Controllers;

[ApiController, Route("api/auth")]
public sealed class AuthController(
    IQueryHandler<GetAvailableUsersQuery, IReadOnlyList<AvailableUserDto>> users,
    ICommandHandler<LoginCommand, SessionDto> login) : ControllerBase
{
    public sealed record LoginRequest(Guid EmployeeId, string Password);

    [AllowAnonymous, HttpGet("users")]
    public Task<IReadOnlyList<AvailableUserDto>> GetUsers(CancellationToken ct) =>
        users.Handle(new GetAvailableUsersQuery(), ct);

    [AllowAnonymous, HttpPost("login")]
    public Task<SessionDto> Login(LoginRequest request, CancellationToken ct) =>
        login.Handle(
            new LoginCommand(request.EmployeeId, request.Password ?? ""),
            ct);
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Tacomanda.Api.Contracts;
using Tacomanda.Application.InicioSesion;

namespace Tacomanda.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/auth")]
public sealed class AuthController : ControllerBase
{
    private readonly IIniciarSesionMediator _mediator;

    public AuthController(IIniciarSesionMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<SesionDto>> IniciarSesion(
        IniciarSesionRequest request,
        CancellationToken cancellationToken)
    {
        IniciarSesionCommand command = new(request.Usuario, request.Password);
        SesionDto respuesta = await _mediator.EnviarAsync(command, cancellationToken);
        return Ok(respuesta);
    }
=======
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
>>>>>>> 4c695f795a46a9ec3b62cb63a997060b28afe20a
}

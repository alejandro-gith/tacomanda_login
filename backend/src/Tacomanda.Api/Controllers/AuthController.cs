using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
}

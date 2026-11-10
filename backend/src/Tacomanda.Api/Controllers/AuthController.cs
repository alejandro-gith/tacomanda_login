using MediatR;
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
    private readonly ISender _mediator;

    public AuthController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<SesionDto>> IniciarSesion(
        IniciarSesionRequest request,
        CancellationToken cancellationToken)
    {
        IniciarSesionCommand command = new(request.Usuario, request.Password);
        SesionDto respuesta = await _mediator.Send(command, cancellationToken);
        return Ok(respuesta);
    }
}

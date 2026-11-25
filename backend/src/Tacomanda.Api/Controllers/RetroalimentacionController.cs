using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tacomanda.Api.Contracts;
using Tacomanda.Application.RegistrarRetroalimentacion;

namespace Tacomanda.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/retroalimentacion")]
public sealed class RetroalimentacionController : ControllerBase
{
    private readonly ISender _mediator;
    public RetroalimentacionController(ISender mediator) { _mediator = mediator; }

    [HttpPost]
    public async Task<ActionResult<RetroalimentacionDto>> Registrar(
        RegistrarRetroalimentacionRequest request, CancellationToken ct)
    {
        RetroalimentacionDto respuesta = await _mediator.Send(new RegistrarRetroalimentacionCommand(
            request.Calificacion, request.Comentario), ct);
        return Ok(respuesta);
    }
}

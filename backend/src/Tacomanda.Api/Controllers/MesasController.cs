using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tacomanda.Application.ConsultarMesas;

namespace Tacomanda.Api.Controllers;

[ApiController]
[Authorize(Roles = "Mesero")]
[Route("api/mesas")]
public sealed class MesasController : ControllerBase
{
    private readonly ISender _mediator;

    public MesasController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<MesaDto>>> Consultar(CancellationToken cancellationToken)
    {
        IReadOnlyList<MesaDto> respuesta = await _mediator.Send(
            new ConsultarMesasQuery(), cancellationToken);
        return Ok(respuesta);
    }
}

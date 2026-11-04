using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tacomanda.Application.ConsultarMesas;

namespace Tacomanda.Api.Controllers;

[ApiController]
[Authorize(Roles = "Mesero")]
[Route("api/mesas")]
public sealed class MesasController : ControllerBase
{
    private readonly IConsultarMesasMediator _mediator;

    public MesasController(IConsultarMesasMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<MesaDto>>> Consultar(CancellationToken cancellationToken)
    {
        IReadOnlyList<MesaDto> respuesta = await _mediator.EnviarAsync(
            new ConsultarMesasQuery(), cancellationToken);
        return Ok(respuesta);
    }
}

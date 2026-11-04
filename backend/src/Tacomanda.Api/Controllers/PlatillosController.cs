using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tacomanda.Application.ConsultarPlatillo;

namespace Tacomanda.Api.Controllers;

[ApiController]
[Authorize(Roles = "Mesero")]
[Route("api/platillos")]
public sealed class PlatillosController : ControllerBase
{
    private readonly IConsultarPlatilloMediator _mediator;

    public PlatillosController(IConsultarPlatilloMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PlatilloDto>>> Consultar(
        CancellationToken cancellationToken,
        [FromQuery] string? categoria = null,
        [FromQuery] int pagina = 1,
        [FromQuery] int tamanoPagina = 100)
    {
        ConsultarPlatilloQuery query = new(categoria, pagina, tamanoPagina);
        IReadOnlyList<PlatilloDto> respuesta = await _mediator.EnviarAsync(query, cancellationToken);
        return Ok(respuesta);
    }
}

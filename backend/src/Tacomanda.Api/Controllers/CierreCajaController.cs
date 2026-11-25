using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tacomanda.Api.Contracts;
using Tacomanda.Application.ConsultarCaja;
using Tacomanda.Application.RegistrarCierreCaja;

namespace Tacomanda.Api.Controllers;

[ApiController]
[Authorize(Roles = "Administrador,Cajero")]
[Route("api/cierre-caja")]
public sealed class CierreCajaController : ControllerBase
{
    private readonly ISender _mediator;
    public CierreCajaController(ISender mediator) { _mediator = mediator; }

    [HttpGet("resumen")]
    public async Task<ActionResult<ResumenCajaDto>> Consultar(CancellationToken ct)
    {
        ResumenCajaDto respuesta = await _mediator.Send(new ConsultarCajaQuery(), ct);
        return Ok(respuesta);
    }

    [HttpPost]
    public async Task<ActionResult<CierreCajaDto>> Registrar(RegistrarCierreCajaRequest request, CancellationToken ct)
    {
        CierreCajaDto respuesta = await _mediator.Send(new RegistrarCierreCajaCommand(
            request.TotalContado, request.HuboIncidencias, request.Comentarios), ct);
        return Ok(respuesta);
    }
}

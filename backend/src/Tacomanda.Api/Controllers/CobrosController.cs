using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tacomanda.Api.Contracts;
using Tacomanda.Application.CobrarComanda;
using Tacomanda.Application.Respuestas;

namespace Tacomanda.Api.Controllers;

[ApiController]
[Authorize(Roles = "Mesero,Cajero")]
[Route("api/comandas/{id:int}/cobro")]
public sealed class CobrosController : ControllerBase
{
    private readonly ISender _mediator;
    public CobrosController(ISender mediator) { _mediator = mediator; }

    [HttpPost]
    public async Task<ActionResult<ComandaDto>> Cobrar(int id, CobrarComandaRequest request, CancellationToken cancellationToken)
    {
        ComandaDto respuesta = await _mediator.Send(new CobrarComandaCommand(
            id, request.FormaPago, request.Monto, request.PorcentajePropina), cancellationToken);
        return Ok(respuesta);
    }
}

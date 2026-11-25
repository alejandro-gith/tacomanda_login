using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tacomanda.Api.Contracts;
using Tacomanda.Api.Mapping;
using Tacomanda.Application.CrearComanda;
using Tacomanda.Application.Respuestas;
using Tacomanda.Application.ConsultarComandas;
using Tacomanda.Application.EditarComanda;
using Tacomanda.Application.CambiarEstadoComanda;

namespace Tacomanda.Api.Controllers;

[ApiController]
[Authorize(Roles = "Mesero,Cajero,Administrador,Cocinero")]
[Route("api/comandas")]
public sealed class ComandasController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly ICrearComandaCommandFactory _commandFactory;

    public ComandasController(ISender mediator, ICrearComandaCommandFactory commandFactory)
    {
        _mediator = mediator;
        _commandFactory = commandFactory;
    }

    [HttpPost]
    [Authorize(Roles = "Mesero")]
    public async Task<ActionResult<ComandaDto>> Crear(
        CrearComandaRequest request,
        CancellationToken cancellationToken)
    {
        CrearComandaCommand command = _commandFactory.Crear(request);
        ComandaDto respuesta = await _mediator.Send(command, cancellationToken);
        return Created($"/api/comandas/{respuesta.Id}", respuesta);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ComandaDto>>> Consultar([FromQuery] string? estado, CancellationToken cancellationToken)
    {
        IReadOnlyList<ComandaDto> respuesta = await _mediator.Send(new ConsultarComandasQuery(estado), cancellationToken);
        return Ok(respuesta);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ComandaDto>> ConsultarPorId(int id, CancellationToken cancellationToken)
    {
        ComandaDto respuesta = await _mediator.Send(new ConsultarComandaQuery(id), cancellationToken);
        return Ok(respuesta);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Mesero")]
    public async Task<ActionResult<ComandaDto>> Editar(int id, EditarComandaRequest request, CancellationToken cancellationToken)
    {
        ComandaDto respuesta = await _mediator.Send(new EditarComandaCommand(id, request.Detalles), cancellationToken);
        return Ok(respuesta);
    }

    [HttpPatch("{id:int}/estado")]
    [Authorize(Roles = "Cocinero")]
    public async Task<ActionResult<ComandaDto>> CambiarEstado(int id, CambiarEstadoComandaRequest request, CancellationToken cancellationToken)
    {
        ComandaDto respuesta = await _mediator.Send(new CambiarEstadoComandaCommand(id, request.Estado), cancellationToken);
        return Ok(respuesta);
    }
}

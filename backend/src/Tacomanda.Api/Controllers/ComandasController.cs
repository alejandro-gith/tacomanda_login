using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tacomanda.Api.Contracts;
using Tacomanda.Api.Mapping;
using Tacomanda.Application.CrearComanda;
using Tacomanda.Application.Respuestas;

namespace Tacomanda.Api.Controllers;

[ApiController]
[Authorize(Roles = "Mesero")]
[Route("api/comandas")]
public sealed class ComandasController : ControllerBase
{
    private readonly ICrearComandaMediator _mediator;
    private readonly ICrearComandaCommandFactory _commandFactory;

    public ComandasController(ICrearComandaMediator mediator, ICrearComandaCommandFactory commandFactory)
    {
        _mediator = mediator;
        _commandFactory = commandFactory;
    }

    [HttpPost]
    public async Task<ActionResult<ComandaDto>> Crear(
        CrearComandaRequest request,
        CancellationToken cancellationToken)
    {
        CrearComandaCommand command = _commandFactory.Crear(request);
        ComandaDto respuesta = await _mediator.EnviarAsync(command, cancellationToken);
        return StatusCode(StatusCodes.Status201Created, respuesta);
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tacomanda.Application.ConsultarPlatillo;
using Tacomanda.Api.Contracts;
using Tacomanda.Application.CrearPlatillo;
using Tacomanda.Application.EditarPlatillo;
using Tacomanda.Application.EliminarPlatillo;

namespace Tacomanda.Api.Controllers;

[ApiController]
[Authorize(Roles = "Mesero,Administrador")]
[Route("api/platillos")]
public sealed class PlatillosController : ControllerBase
{
    private readonly ISender _mediator;

    public PlatillosController(ISender mediator)
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
        IReadOnlyList<PlatilloDto> respuesta = await _mediator.Send(query, cancellationToken);
        return Ok(respuesta);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<PlatilloDto>> Crear(PlatilloRequest request, CancellationToken cancellationToken)
    {
        CrearPlatilloCommand command = new(request.Nombre, request.Categoria, request.Descripcion, request.Precio, request.Emoji);
        PlatilloDto respuesta = await _mediator.Send(command, cancellationToken);
        return Created($"/api/platillos/{respuesta.Id}", respuesta);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<PlatilloDto>> Editar(Guid id, PlatilloRequest request, CancellationToken cancellationToken)
    {
        EditarPlatilloCommand command = new(id, request.Nombre, request.Categoria, request.Descripcion, request.Precio, request.Emoji);
        PlatilloDto respuesta = await _mediator.Send(command, cancellationToken);
        return Ok(respuesta);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Eliminar(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new EliminarPlatilloCommand(id), cancellationToken);
        return NoContent();
    }
}

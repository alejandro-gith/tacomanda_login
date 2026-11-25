using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tacomanda.Api.Contracts;
using Tacomanda.Application.AltaEmpleado;

namespace Tacomanda.Api.Controllers;

[ApiController]
[Authorize(Roles = "Administrador")]
[Route("api/empleados")]
public sealed class EmpleadosController : ControllerBase
{
    private readonly ISender _mediator;

    public EmpleadosController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<EmpleadoDto>> Alta(AltaEmpleadoRequest request, CancellationToken cancellationToken)
    {
        AltaEmpleadoCommand command = new(request.Usuario, request.Nombre, request.Password, request.Rol);
        EmpleadoDto respuesta = await _mediator.Send(command, cancellationToken);
        return Created($"/api/empleados/{respuesta.Id}", respuesta);
    }
}

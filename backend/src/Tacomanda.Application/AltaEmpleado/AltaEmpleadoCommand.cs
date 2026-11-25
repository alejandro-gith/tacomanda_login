using MediatR;

namespace Tacomanda.Application.AltaEmpleado;

public sealed record AltaEmpleadoCommand(string Usuario, string Nombre, string Password, string Rol)
    : IRequest<EmpleadoDto>;

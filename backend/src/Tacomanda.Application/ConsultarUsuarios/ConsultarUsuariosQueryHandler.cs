using MediatR;
using Tacomanda.Domain.Empleados;

namespace Tacomanda.Application.ConsultarUsuarios;

public sealed class ConsultarUsuariosQueryHandler : IRequestHandler<ConsultarUsuariosQuery, IReadOnlyList<UsuarioDisponibleDto>>
{
    private readonly IEmpleadoReader _reader;

    public ConsultarUsuariosQueryHandler(IEmpleadoReader reader)
    {
        _reader = reader;
    }

    public async Task<IReadOnlyList<UsuarioDisponibleDto>> Handle(ConsultarUsuariosQuery query,
        CancellationToken cancellationToken)
    {
        IReadOnlyList<Empleado> empleados = await _reader.ListarActivosAsync(cancellationToken);
        return empleados.Select(e => new UsuarioDisponibleDto(e.Id, e.Usuario, e.Nombre, e.Rol.ToString())).ToList();
    }
}

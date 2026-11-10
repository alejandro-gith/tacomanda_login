using MediatR;
using Tacomanda.Application.Seguridad;
using Tacomanda.Domain.Empleados;
using Tacomanda.Domain.Excepciones;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Application.AltaEmpleado;

public sealed class AltaEmpleadoHandler : IRequestHandler<AltaEmpleadoCommand, EmpleadoDto>
{
    private readonly IEmpleadoRepository _lectura;
    private readonly IAltaEmpleadoRepository _escritura;
    private readonly IPasswordEncoder _encoder;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;

    public AltaEmpleadoHandler(IEmpleadoRepository lectura, IAltaEmpleadoRepository escritura,
        IPasswordEncoder encoder, IUnidadDeTrabajo unidadDeTrabajo)
    {
        _lectura = lectura;
        _escritura = escritura;
        _encoder = encoder;
        _unidadDeTrabajo = unidadDeTrabajo;
    }

    public async Task<EmpleadoDto> Handle(AltaEmpleadoCommand command, CancellationToken cancellationToken)
    {
        string usuario = command.Usuario.Trim().ToLowerInvariant();
        if (await _lectura.BuscarPorUsuarioAsync(usuario, cancellationToken) is not null)
        {
            throw new ReglaDeNegocioException("El usuario ya existe.");
        }

        EmployeeRole rol = command.Rol == "Mesero" ? EmployeeRole.Mesero : EmployeeRole.Cajero;
        Empleado empleado = new(Guid.NewGuid(), usuario, command.Nombre.Trim(),
            _encoder.Codificar(command.Password), rol);
        _escritura.Agregar(empleado);
        await _unidadDeTrabajo.ConfirmarAsync(cancellationToken);
        return new EmpleadoDto(empleado.Id, empleado.Usuario, empleado.Nombre, empleado.Rol.ToString());
    }
}

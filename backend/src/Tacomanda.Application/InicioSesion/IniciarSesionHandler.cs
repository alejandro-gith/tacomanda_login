using MediatR;
using Tacomanda.Application.Seguridad;
using Tacomanda.Domain.Empleados;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Application.InicioSesion;

public sealed class IniciarSesionHandler : IRequestHandler<IniciarSesionCommand, SesionDto>
{
    private readonly IEmpleadoRepository _empleados;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;

    public IniciarSesionHandler(
        IEmpleadoRepository empleados,
        IPasswordHasher passwordHasher,
        ITokenService tokenService)
    {
        _empleados = empleados;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<SesionDto> Handle(
        IniciarSesionCommand command,
        CancellationToken cancellationToken)
    {
        Empleado? empleado = await _empleados.BuscarPorUsuarioAsync(
            command.Usuario, cancellationToken);

        if (empleado is null || !empleado.Activo ||
            !_passwordHasher.Verificar(command.Password, empleado.PasswordHash))
        {
            throw new UnauthorizedAccessException("Credenciales inválidas.");
        }

        TokenDto token = _tokenService.Generar(empleado);

        return new SesionDto(
            empleado.Id, empleado.Usuario, empleado.Nombre, empleado.Rol.ToString(),
            token.AccessToken, token.ExpiraEn);
    }
}

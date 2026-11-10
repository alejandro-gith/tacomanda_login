using Tacomanda.Application.Validacion;

namespace Tacomanda.Application.InicioSesion;

public sealed class IniciarSesionValidator : IValidator<IniciarSesionCommand>
{
    public void Validar(IniciarSesionCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Usuario) || command.Usuario.Length > 80)
        {
            throw new ValidacionException("El usuario es requerido y permite hasta 80 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(command.Password) ||
            command.Password.Length < 8 || command.Password.Length > 128)
        {
            throw new ValidacionException("La contraseña requiere entre 8 y 128 caracteres.");
        }
    }
}

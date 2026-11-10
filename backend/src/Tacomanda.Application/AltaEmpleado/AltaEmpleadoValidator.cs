using Tacomanda.Application.Validacion;

namespace Tacomanda.Application.AltaEmpleado;

public sealed class AltaEmpleadoValidator : IValidator<AltaEmpleadoCommand>
{
    public void Validar(AltaEmpleadoCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Usuario) || command.Usuario.Length > 80 ||
            !System.Text.RegularExpressions.Regex.IsMatch(command.Usuario, "^[a-zA-Z0-9._-]+$") ||
            string.IsNullOrWhiteSpace(command.Nombre) || command.Nombre.Length > 100 ||
            command.Password is null || command.Password.Length < 8 || command.Password.Length > 128 ||
            (command.Rol != "Mesero" && command.Rol != "Cajero"))
        {
            throw new ValidacionException("Datos de empleado inválidos.");
        }
    }
}

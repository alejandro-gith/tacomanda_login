using Tacomanda.Application.Validacion;

namespace Tacomanda.Application.CrearPlatillo;

public sealed class CrearPlatilloValidator : IValidator<CrearPlatilloCommand>
{
    public void Validar(CrearPlatilloCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Nombre) || command.Nombre.Length > 100 ||
            string.IsNullOrWhiteSpace(command.Categoria) || command.Categoria.Length > 60 ||
            command.Descripcion is null || command.Descripcion.Length > 500 ||
            command.Emoji is null || command.Emoji.Length > 16 ||
            command.Precio <= 0 || command.Precio > 100000)
        {
            throw new ValidacionException("Datos de platillo inválidos.");
        }
    }
}

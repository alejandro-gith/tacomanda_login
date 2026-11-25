using Tacomanda.Application.Validacion;

namespace Tacomanda.Application.EditarPlatillo;

public sealed class EditarPlatilloValidator : IValidator<EditarPlatilloCommand>
{
    public void Validar(EditarPlatilloCommand command)
    {
        if (command.Id <= 0 || string.IsNullOrWhiteSpace(command.Nombre) || command.Nombre.Length > 50 ||
            string.IsNullOrWhiteSpace(command.Categoria) || command.Categoria.Length > 25 ||
            command.Descripcion is null || command.Descripcion.Length > 100 ||
            command.Emoji is null || command.Emoji.Length > 8 ||
            command.Precio <= 0 || command.Precio > 100000 ||
            decimal.Round(command.Precio, 2) != command.Precio)
        {
            throw new ValidacionException("Datos de platillo inválidos.");
        }
    }
}

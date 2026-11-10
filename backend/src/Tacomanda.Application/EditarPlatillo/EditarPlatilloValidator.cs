using Tacomanda.Application.Validacion;

namespace Tacomanda.Application.EditarPlatillo;

public sealed class EditarPlatilloValidator : IValidator<EditarPlatilloCommand>
{
    public void Validar(EditarPlatilloCommand command)
    {
        if (command.Id == Guid.Empty || string.IsNullOrWhiteSpace(command.Nombre) || command.Nombre.Length > 100 ||
            string.IsNullOrWhiteSpace(command.Categoria) || command.Categoria.Length > 60 ||
            command.Descripcion is null || command.Descripcion.Length > 500 ||
            command.Emoji is null || command.Emoji.Length > 16 ||
            command.Precio <= 0 || command.Precio > 100000)
        {
            throw new ValidacionException("Datos de platillo inválidos.");
        }
    }
}

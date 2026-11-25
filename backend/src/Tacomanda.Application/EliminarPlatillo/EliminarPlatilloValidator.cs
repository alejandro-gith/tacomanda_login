using Tacomanda.Application.Validacion;

namespace Tacomanda.Application.EliminarPlatillo;

public sealed class EliminarPlatilloValidator : IValidator<EliminarPlatilloCommand>
{
    public void Validar(EliminarPlatilloCommand command)
    {
        if (command.Id <= 0)
        {
            throw new ValidacionException("El identificador es requerido.");
        }
    }
}

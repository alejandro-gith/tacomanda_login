using Tacomanda.Application.Validacion;

namespace Tacomanda.Application.CambiarEstadoComanda;

public sealed class CambiarEstadoComandaValidator : IValidator<CambiarEstadoComandaCommand>
{
    public void Validar(CambiarEstadoComandaCommand command)
    {
        if (command.Id <= 0 || command.Estado is not ("EnPreparacion" or "Lista"))
            throw new ValidacionException("Estado o identificador inválido.");
    }
}

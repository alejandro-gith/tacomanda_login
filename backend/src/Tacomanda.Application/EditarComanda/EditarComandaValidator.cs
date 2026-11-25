using Tacomanda.Application.Validacion;

namespace Tacomanda.Application.EditarComanda;

public sealed class EditarComandaValidator : IValidator<EditarComandaCommand>
{
    public void Validar(EditarComandaCommand command)
    {
        if (command.Id <= 0 || command.Detalles is null || command.Detalles.Count is < 1 or > 100 ||
            command.Detalles.Any(d => d is null || d.PlatilloId <= 0 || d.Cantidad is < 1 or > 99 ||
                d.Observaciones is null || d.Observaciones.Length > 200) ||
            command.Detalles.Select(d => d.PlatilloId).Distinct().Count() != command.Detalles.Count)
            throw new ValidacionException("Detalles de comanda inválidos.");
    }
}

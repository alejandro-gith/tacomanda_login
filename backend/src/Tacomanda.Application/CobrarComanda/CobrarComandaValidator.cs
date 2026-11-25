using Tacomanda.Application.Validacion;

namespace Tacomanda.Application.CobrarComanda;

public sealed class CobrarComandaValidator : IValidator<CobrarComandaCommand>
{
    public void Validar(CobrarComandaCommand command)
    {
        if (command.Id <= 0 || command.Monto <= 0 || command.Monto > 999999.99m ||
            decimal.Round(command.Monto, 2) != command.Monto || command.FormaPago is not ("Efectivo" or "Tarjeta") ||
            command.PorcentajePropina < 0 || command.PorcentajePropina > 100 ||
            (command.PorcentajePropina > 0 && command.PorcentajePropina < 15) ||
            decimal.Round(command.PorcentajePropina, 2) != command.PorcentajePropina)
            throw new ValidacionException("Datos de cobro inválidos.");
    }
}

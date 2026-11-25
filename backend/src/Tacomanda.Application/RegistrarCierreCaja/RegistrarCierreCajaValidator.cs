using Tacomanda.Application.Validacion;

namespace Tacomanda.Application.RegistrarCierreCaja;

public sealed class RegistrarCierreCajaValidator : IValidator<RegistrarCierreCajaCommand>
{
    public void Validar(RegistrarCierreCajaCommand command)
    {
        if (command.TotalContado < 0 || command.TotalContado > 99999999.99m ||
            decimal.Round(command.TotalContado, 2) != command.TotalContado ||
            command.Comentarios is null || command.Comentarios.Length > 2000)
            throw new ValidacionException("Datos del cierre inválidos.");
    }
}

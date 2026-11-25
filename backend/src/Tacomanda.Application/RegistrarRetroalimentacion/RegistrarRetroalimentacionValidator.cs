using Tacomanda.Application.Validacion;

namespace Tacomanda.Application.RegistrarRetroalimentacion;

public sealed class RegistrarRetroalimentacionValidator : IValidator<RegistrarRetroalimentacionCommand>
{
    public void Validar(RegistrarRetroalimentacionCommand command)
    {
        if (command.Calificacion is < 1 or > 5 || command.Comentario is null || command.Comentario.Length > 2000)
            throw new ValidacionException("Retroalimentación inválida.");
    }
}

namespace Tacomanda.Domain.Interfaces;

public interface IUnidadDeTrabajo
{
    Task ConfirmarAsync(CancellationToken cancellationToken);
}

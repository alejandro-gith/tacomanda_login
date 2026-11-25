using RetroalimentacionEntidad = Tacomanda.Domain.Retroalimentacion.Retroalimentacion;

namespace Tacomanda.Domain.Interfaces;

public interface IRetroalimentacionRepository
{
    void Agregar(RetroalimentacionEntidad retroalimentacion);
}

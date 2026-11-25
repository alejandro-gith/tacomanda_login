using MediatR;
using Tacomanda.Application.Respuestas;

namespace Tacomanda.Application.CrearComanda;

public sealed class CrearComandaCommand : IRequest<ComandaDto>
{
    public CrearComandaCommand(int mesaId, int meseroId, IEnumerable<DetalleComandaInput> detalles)
    {
        MesaId = mesaId;
        MeseroId = meseroId;
        Detalles = new List<DetalleComandaInput>(detalles).AsReadOnly();
    }

    public int MesaId { get; }
    public int MeseroId { get; }
    public IReadOnlyList<DetalleComandaInput> Detalles { get; }
}

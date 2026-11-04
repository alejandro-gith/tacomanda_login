namespace Tacomanda.Application.CrearComanda;

public sealed class CrearComandaCommand
{
    public CrearComandaCommand(Guid mesaId, Guid meseroId, IEnumerable<DetalleComandaInput> detalles)
    {
        MesaId = mesaId;
        MeseroId = meseroId;
        Detalles = new List<DetalleComandaInput>(detalles).AsReadOnly();
    }

    public Guid MesaId { get; }
    public Guid MeseroId { get; }
    public IReadOnlyList<DetalleComandaInput> Detalles { get; }
}

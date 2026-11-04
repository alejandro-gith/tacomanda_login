using Tacomanda.Domain.Mesas;

namespace Tacomanda.Application.ConsultarMesas;

public sealed class ConsultarMesasQueryHandler : IConsultarMesasQueryHandler
{
    private readonly IMesaReader _reader;

    public ConsultarMesasQueryHandler(IMesaReader reader)
    {
        _reader = reader;
    }

    public async Task<IReadOnlyList<MesaDto>> Handle(
        ConsultarMesasQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Mesa> mesas = await _reader.LeerAsync(cancellationToken);
        List<MesaDto> resultado = new();
        foreach (Mesa mesa in mesas)
        {
            resultado.Add(new MesaDto(mesa.Id, mesa.Nombre, mesa.Disponible));
        }
        return resultado.AsReadOnly();
    }
}

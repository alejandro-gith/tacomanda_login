using AutoMapper;
using MediatR;
using Tacomanda.Application.Respuestas;
using Tacomanda.Domain.Comandas;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Application.CambiarEstadoComanda;

public sealed class CambiarEstadoComandaHandler : IRequestHandler<CambiarEstadoComandaCommand, ComandaDto>
{
    private readonly IComandaRepository _comandas;
    private readonly IUnidadDeTrabajo _unidad;
    private readonly IMapper _mapper;
    public CambiarEstadoComandaHandler(IComandaRepository comandas, IUnidadDeTrabajo unidad, IMapper mapper)
    { _comandas = comandas; _unidad = unidad; _mapper = mapper; }
    public async Task<ComandaDto> Handle(CambiarEstadoComandaCommand command, CancellationToken ct)
    {
        Comanda comanda = await _comandas.ObtenerAsync(command.Id, ct)
            ?? throw new KeyNotFoundException("Comanda inexistente.");
        comanda.CambiarEstado(Enum.Parse<OrderStatus>(command.Estado));
        await _unidad.ConfirmarAsync(ct);
        return _mapper.Map<ComandaDto>(comanda);
    }
}

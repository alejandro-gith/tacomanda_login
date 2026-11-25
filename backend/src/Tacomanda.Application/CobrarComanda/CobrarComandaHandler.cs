using AutoMapper;
using MediatR;
using Tacomanda.Application.Respuestas;
using Tacomanda.Application.Seguridad;
using Tacomanda.Domain.Comandas;
using Tacomanda.Domain.Excepciones;
using Tacomanda.Domain.Interfaces;
using Tacomanda.Domain.Mesas;
using Tacomanda.Domain.Pagos;

namespace Tacomanda.Application.CobrarComanda;

public sealed class CobrarComandaHandler : IRequestHandler<CobrarComandaCommand, ComandaDto>
{
    private readonly IComandaRepository _comandas;
    private readonly IMesaRepository _mesas;
    private readonly IPagoRepository _pagos;
    private readonly SelectorPoliticaPago _selector;
    private readonly IUsuarioActual _usuario;
    private readonly IUnidadDeTrabajo _unidad;
    private readonly IMapper _mapper;
    public CobrarComandaHandler(IComandaRepository comandas, IMesaRepository mesas, IPagoRepository pagos,
        SelectorPoliticaPago selector, IUsuarioActual usuario, IUnidadDeTrabajo unidad, IMapper mapper)
    { _comandas = comandas; _mesas = mesas; _pagos = pagos; _selector = selector; _usuario = usuario; _unidad = unidad; _mapper = mapper; }

    public async Task<ComandaDto> Handle(CobrarComandaCommand command, CancellationToken ct)
    {
        Comanda comanda = await _comandas.ObtenerAsync(command.Id, ct)
            ?? throw new KeyNotFoundException("Comanda inexistente.");
        int empleadoId = _usuario.ObtenerId();
        string rol = _usuario.ObtenerRol();
        if (rol != "Cajero" && (rol != "Mesero" || comanda.MeseroId != empleadoId))
            throw new UnauthorizedAccessException("No se permite cobrar esta comanda.");
        if (comanda.Estado != OrderStatus.Lista) throw new ReglaDeNegocioException("La comanda aún no está lista.");
        decimal propina = decimal.Round(comanda.Total * command.PorcentajePropina / 100,
            2, MidpointRounding.AwayFromZero);
        IPoliticaDePago politica = _selector.Elegir(command.FormaPago);
        politica.Validar(comanda.Total + propina, command.Monto);
        Mesa mesa = await _mesas.ObtenerAsync(comanda.MesaId, ct) ?? throw new KeyNotFoundException("Mesa inexistente.");
        comanda.Cobrar(command.FormaPago, command.Monto, command.PorcentajePropina);
        mesa.Liberar();
        _pagos.Agregar(new Pago(comanda.Id, empleadoId, command.FormaPago, command.Monto,
            comanda.Total, comanda.Propina));
        await _unidad.ConfirmarAsync(ct);
        return _mapper.Map<ComandaDto>(comanda);
    }
}

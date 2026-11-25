using AutoMapper;
using MediatR;
using Tacomanda.Application.Respuestas;
using Tacomanda.Application.Seguridad;
using Tacomanda.Application.Validacion;
using Tacomanda.Domain.Comandas;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Application.ConsultarComandas;

public sealed class ConsultarComandasQueryHandler : IRequestHandler<ConsultarComandasQuery, IReadOnlyList<ComandaDto>>
{
    private readonly IComandaReader _reader;
    private readonly IUsuarioActual _usuario;
    private readonly IMapper _mapper;
    public ConsultarComandasQueryHandler(IComandaReader reader, IUsuarioActual usuario, IMapper mapper)
    { _reader = reader; _usuario = usuario; _mapper = mapper; }

    public async Task<IReadOnlyList<ComandaDto>> Handle(ConsultarComandasQuery query, CancellationToken ct)
    {
        if (query.Estado is not null &&
            (!Enum.TryParse<OrderStatus>(query.Estado, true, out OrderStatus solicitado) || !Enum.IsDefined(solicitado)))
            throw new ValidacionException("Estado inválido.");
        string rol = _usuario.ObtenerRol();
        int id = _usuario.ObtenerId();
        OrderStatus? filtro = query.Estado is null ? null : Enum.Parse<OrderStatus>(query.Estado, true);
        IReadOnlyList<Comanda> comandas = await _reader.ListarAsync(
            rol == "Mesero" ? id : null, filtro, rol == "Cocinero", ct);
        return comandas.Select(c => _mapper.Map<ComandaDto>(c)).ToList();
    }
}

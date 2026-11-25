using AutoMapper;
using MediatR;
using Tacomanda.Domain.Mesas;

namespace Tacomanda.Application.ConsultarMesas;

public sealed class ConsultarMesasQueryHandler : IRequestHandler<ConsultarMesasQuery, IReadOnlyList<MesaDto>>
{
    private readonly IMesaReader _reader;
    private readonly IMapper _mapper;

    public ConsultarMesasQueryHandler(IMesaReader reader, IMapper mapper)
    {
        _reader = reader;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<MesaDto>> Handle(
        ConsultarMesasQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Mesa> mesas = await _reader.LeerAsync(cancellationToken);
        return _mapper.Map<IReadOnlyList<MesaDto>>(mesas);
    }
}

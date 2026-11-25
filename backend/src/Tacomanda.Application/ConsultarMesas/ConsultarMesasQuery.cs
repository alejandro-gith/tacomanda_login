using MediatR;

namespace Tacomanda.Application.ConsultarMesas;

public sealed record ConsultarMesasQuery : IRequest<IReadOnlyList<MesaDto>>;

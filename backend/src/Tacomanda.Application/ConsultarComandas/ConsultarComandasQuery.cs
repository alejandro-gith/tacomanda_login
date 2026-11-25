using MediatR;
using Tacomanda.Application.Respuestas;

namespace Tacomanda.Application.ConsultarComandas;

public sealed record ConsultarComandasQuery(string? Estado = null) : IRequest<IReadOnlyList<ComandaDto>>;

using MediatR;
using Tacomanda.Application.Respuestas;

namespace Tacomanda.Application.ConsultarComandas;

public sealed record ConsultarComandaQuery(int Id) : IRequest<ComandaDto>;

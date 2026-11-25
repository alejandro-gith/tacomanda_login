using MediatR;
using Tacomanda.Application.Respuestas;

namespace Tacomanda.Application.CambiarEstadoComanda;

public sealed record CambiarEstadoComandaCommand(int Id, string Estado) : IRequest<ComandaDto>;

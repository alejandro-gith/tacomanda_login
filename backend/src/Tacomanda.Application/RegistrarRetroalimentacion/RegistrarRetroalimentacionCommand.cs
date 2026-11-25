using MediatR;

namespace Tacomanda.Application.RegistrarRetroalimentacion;

public sealed record RegistrarRetroalimentacionCommand(int Calificacion, string Comentario) : IRequest<RetroalimentacionDto>;

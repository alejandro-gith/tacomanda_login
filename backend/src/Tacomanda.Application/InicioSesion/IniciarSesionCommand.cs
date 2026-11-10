using MediatR;

namespace Tacomanda.Application.InicioSesion;

public sealed record IniciarSesionCommand(string Usuario, string Password) : IRequest<SesionDto>;

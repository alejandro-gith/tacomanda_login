using MediatR;

namespace Tacomanda.Application.ConsultarUsuarios;

public sealed record ConsultarUsuariosQuery() : IRequest<IReadOnlyList<UsuarioDisponibleDto>>;

using Microsoft.Extensions.Configuration;
using Tacomanda.Application.Seguridad;
using Tacomanda.Domain.Empleados;

namespace Tacomanda.Infrastructure.Seed;

// Crea el primer administrador fuera de Development una sola vez.
public sealed class BootstrapAdmin
{
    private readonly IDatosDePruebaRepository _repository;
    private readonly IPasswordEncoder _passwordEncoder;
    private readonly IConfiguration _configuration;

    public BootstrapAdmin(IDatosDePruebaRepository repository, IPasswordEncoder passwordEncoder,
        IConfiguration configuration)
    {
        _repository = repository;
        _passwordEncoder = passwordEncoder;
        _configuration = configuration;
    }

    public async Task InicializarAsync(CancellationToken cancellationToken)
    {
        if (await _repository.ExistenAsync(cancellationToken)) return;
        string usuario = _configuration["BootstrapAdmin:Username"] ?? "";
        string password = _configuration["BootstrapAdmin:Password"] ?? "";
        if (string.IsNullOrWhiteSpace(usuario) || usuario.Length > 80 ||
            !System.Text.RegularExpressions.Regex.IsMatch(usuario, "^[a-zA-Z0-9._-]+$") ||
            password.Length is < 8 or > 128)
            throw new InvalidOperationException("Configure BootstrapAdmin:Username y una contraseña segura de 8-128 caracteres.");
        Empleado admin = new(0, usuario.Trim().ToLowerInvariant(), "Administrador",
            _passwordEncoder.Codificar(password), EmployeeRole.Administrador);
        await _repository.GuardarAsync(new[] { admin }, cancellationToken);
    }
}

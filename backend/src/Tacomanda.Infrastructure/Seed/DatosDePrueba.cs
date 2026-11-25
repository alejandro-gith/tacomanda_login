using Microsoft.Extensions.Configuration;
using Tacomanda.Application.Seguridad;
using Tacomanda.Domain.Empleados;

namespace Tacomanda.Infrastructure.Seed;

// Solo en Development; las mesas, productos y platillos provienen de database/schema.sql.
public sealed class DatosDePrueba
{
    private readonly IDatosDePruebaRepository _repository;
    private readonly IPasswordEncoder _passwordEncoder;
    private readonly IConfiguration _configuration;

    public DatosDePrueba(IDatosDePruebaRepository repository, IPasswordEncoder passwordEncoder, IConfiguration configuration)
    {
        _repository = repository;
        _passwordEncoder = passwordEncoder;
        _configuration = configuration;
    }

    public async Task InicializarAsync(CancellationToken cancellationToken)
    {
        if (await _repository.ExistenAsync(cancellationToken)) return;

        List<Empleado> empleados = new();
        foreach (IConfigurationSection usuario in _configuration.GetSection("DevelopmentUsers").GetChildren())
        {
            string nombreUsuario = usuario["Username"] ?? throw new InvalidOperationException("Falta Username.");
            string nombre = usuario["DisplayName"] ?? throw new InvalidOperationException("Falta DisplayName.");
            string password = usuario["Password"] ?? throw new InvalidOperationException("Falta Password.");
            string rolTexto = usuario["Role"] ?? throw new InvalidOperationException("Falta Role.");
            if (!Enum.TryParse(rolTexto, true, out EmployeeRole rol))
                throw new InvalidOperationException("Rol de desarrollo no válido.");
            empleados.Add(new Empleado(0, nombreUsuario, nombre, _passwordEncoder.Codificar(password), rol));
        }

        if (empleados.Count == 0)
            throw new InvalidOperationException("Configure DevelopmentUsers antes de iniciar la API.");
        await _repository.GuardarAsync(empleados, cancellationToken);
    }
}

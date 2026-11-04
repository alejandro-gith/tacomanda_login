using Tacomanda.Application.Seguridad;
using Tacomanda.Domain.Empleados;
using Tacomanda.Domain.Mesas;
using Tacomanda.Domain.Platillos;

namespace Tacomanda.Infrastructure.Seed;

public sealed class DatosDePrueba
{
    private readonly IDatosDePruebaRepository _repository;
    private readonly IPasswordEncoder _passwordEncoder;

    public DatosDePrueba(IDatosDePruebaRepository repository, IPasswordEncoder passwordEncoder)
    {
        _repository = repository;
        _passwordEncoder = passwordEncoder;
    }

    public async Task InicializarAsync(CancellationToken cancellationToken)
    {
        if (await _repository.ExistenAsync(cancellationToken))
        {
            return;
        }

        List<Empleado> empleados = new();
        List<Mesa> mesas = new();

        empleados.Add(new Empleado(
            Guid.Parse("11111111-1111-1111-1111-111111111111"),
            "mesero", "Mesero local", _passwordEncoder.Codificar("mesero123"), EmployeeRole.Mesero));
        empleados.Add(new Empleado(
            Guid.Parse("22222222-2222-2222-2222-222222222222"),
            "cajero", "Cajero local", _passwordEncoder.Codificar("cajero123"), EmployeeRole.Cajero));

        for (int numero = 1; numero <= 8; numero++)
        {
            mesas.Add(new Mesa(Guid.NewGuid(), "Mesa " + numero));
        }

        Platillo[] platillos =
        {
            new Platillo(Guid.NewGuid(), "Taco al pastor", "Tacos", "Pastor con piña", 20, "🌮"),
            new Platillo(Guid.NewGuid(), "Taco de bistec", "Tacos", "Bistec a la plancha", 25, "🌮"),
            new Platillo(Guid.NewGuid(), "Gringa", "Especialidades", "Pastor con queso", 55, "🫓"),
            new Platillo(Guid.NewGuid(), "Quesadilla", "Especialidades", "Queso fundido", 30, "🧀"),
            new Platillo(Guid.NewGuid(), "Agua de horchata", "Bebidas", "Vaso de 500 ml", 25, "🥤"),
            new Platillo(Guid.NewGuid(), "Refresco", "Bebidas", "Botella de 355 ml", 25, "🥤")
        };

        await _repository.GuardarAsync(empleados, mesas, platillos, cancellationToken);
    }
}

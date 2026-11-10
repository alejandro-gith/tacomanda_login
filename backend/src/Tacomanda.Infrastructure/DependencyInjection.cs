using Microsoft.Extensions.DependencyInjection;
using Tacomanda.Application.ConsultarMesas;
using Tacomanda.Application.ConsultarPlatillo;
using Tacomanda.Application.Seguridad;
using Tacomanda.Domain.Interfaces;
using Tacomanda.Infrastructure.Persistence;
using Tacomanda.Infrastructure.Persistence.Readers;
using Tacomanda.Infrastructure.Persistence.Repositories;
using Tacomanda.Infrastructure.Seed;
using Tacomanda.Infrastructure.Seguridad;

namespace Tacomanda.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<BaseDeDatosMemoria>();
        services.AddDbContext<TacomandaDbContext>(ConfigurarBaseDeDatos);
        services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajoRepository>();
        services.AddScoped<IPlatillosLecturaRepository, PlatillosLecturaRepository>();
        services.AddScoped<IMesasLecturaRepository, MesasLecturaRepository>();
        services.AddScoped<IMeseroRepository, MeseroRepository>();
        services.AddScoped<IDatosDePruebaRepository, DatosDePruebaRepository>();
        services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
        services.AddScoped<IAltaEmpleadoRepository, EmpleadoRepository>();
        services.AddScoped<IMesaRepository, MesaRepository>();
        services.AddScoped<IPlatilloRepository, PlatilloRepository>();
        services.AddScoped<IPlatillosEscrituraRepository, PlatilloRepository>();
        services.AddScoped<IComandaRepository, ComandaRepository>();
        services.AddScoped<IMesaReader, MesaReader>();
        services.AddScoped<IPlatilloReader, PlatilloReader>();
        services.AddSingleton<IPasswordHasher, Pbkdf2PasswordHasher>();
        services.AddSingleton<IPasswordEncoder, Pbkdf2PasswordHasher>();
        services.AddSingleton<ITokenService, JwtTokenService>();
        services.AddScoped<DatosDePrueba>();
        return services;
    }

    private static void ConfigurarBaseDeDatos(
        IServiceProvider provider, Microsoft.EntityFrameworkCore.DbContextOptionsBuilder options)
    {
        provider.GetRequiredService<BaseDeDatosMemoria>().Configurar(options);
    }

}

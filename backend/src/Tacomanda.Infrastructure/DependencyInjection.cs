using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tacomanda.Application.ConsultarMesas;
using Tacomanda.Application.ConsultarPlatillo;
using Tacomanda.Application.ConsultarUsuarios;
using Tacomanda.Application.ConsultarCaja;
using Tacomanda.Application.Seguridad;
using Tacomanda.Domain.Interfaces;
using Tacomanda.Domain.Pagos;
using Tacomanda.Application.CobrarComanda;
using Tacomanda.Infrastructure.Persistence;
using Tacomanda.Infrastructure.Persistence.Readers;
using Tacomanda.Infrastructure.Persistence.Repositories;
using Tacomanda.Infrastructure.Seed;
using Tacomanda.Infrastructure.Seguridad;

namespace Tacomanda.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Tacomanda")
            ?? throw new InvalidOperationException("Configure ConnectionStrings:Tacomanda para MySQL.");
        services.AddDbContext<TacomandaDbContext>(options => options.UseMySQL(connectionString));
        services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajoRepository>();
        services.AddScoped<IPlatillosLecturaRepository, PlatillosLecturaRepository>();
        services.AddScoped<IMesasLecturaRepository, MesasLecturaRepository>();
        services.AddScoped<IMeseroRepository, MeseroRepository>();
        services.AddScoped<IDatosDePruebaRepository, DatosDePruebaRepository>();
        services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
        services.AddScoped<IEmpleadosLecturaRepository, EmpleadosLecturaRepository>();
        services.AddScoped<IEmpleadoReader, EmpleadoReader>();
        services.AddScoped<IAltaEmpleadoRepository, EmpleadoRepository>();
        services.AddScoped<IMesaRepository, MesaRepository>();
        services.AddScoped<IPlatilloRepository, PlatilloRepository>();
        services.AddScoped<IPlatillosEscrituraRepository, PlatilloRepository>();
        services.AddScoped<IComandaRepository, ComandaRepository>();
        services.AddScoped<IComandasLecturaRepository, ComandasLecturaRepository>();
        services.AddScoped<IComandaReader, ComandaReader>();
        services.AddScoped<ICierresLecturaRepository, CierresLecturaRepository>();
        services.AddScoped<ICierreCajaRepository, CierreCajaRepository>();
        services.AddScoped<IResumenCajaReader, ResumenCajaReader>();
        services.AddScoped<IRetroalimentacionRepository, RetroalimentacionRepository>();
        services.AddScoped<IPagoRepository, PagoRepository>();
        services.AddScoped<IPoliticaDePago, PoliticaEfectivo>();
        services.AddScoped<IPoliticaDePago, PoliticaTarjeta>();
        services.AddScoped<SelectorPoliticaPago>();
        services.AddScoped<IMesaReader, MesaReader>();
        services.AddScoped<IPlatilloReader, PlatilloReader>();
        services.AddSingleton<IPasswordHasher, Pbkdf2PasswordHasher>();
        services.AddSingleton<IPasswordEncoder, Pbkdf2PasswordHasher>();
        services.AddSingleton<ITokenService, JwtTokenService>();
        services.AddScoped<DatosDePrueba>();
        services.AddScoped<BootstrapAdmin>();
        return services;
    }

}

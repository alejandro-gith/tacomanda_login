using Microsoft.Extensions.DependencyInjection;
using Tacomanda.Application.ConsultarMesas;
using Tacomanda.Application.ConsultarPlatillo;
using Tacomanda.Application.CrearComanda;
using Tacomanda.Application.InicioSesion;
using Tacomanda.Application.Respuestas;

namespace Tacomanda.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IIniciarSesionValidator, IniciarSesionValidator>();
        services.AddTransient<IIniciarSesionHandler, IniciarSesionHandler>();
        services.AddTransient<IIniciarSesionMediator, IniciarSesionMediator>();

        services.AddTransient<ICrearComandaValidator, CrearComandaValidator>();
        services.AddTransient<ICrearComandaHandler, CrearComandaHandler>();
        services.AddTransient<ICrearComandaMediator, CrearComandaMediator>();

        services.AddTransient<IConsultarMesasQueryHandler, ConsultarMesasQueryHandler>();
        services.AddTransient<IConsultarMesasMediator, ConsultarMesasMediator>();
        services.AddTransient<IConsultarPlatilloQueryHandler, ConsultarPlatilloQueryHandler>();
        services.AddTransient<IConsultarPlatilloMediator, ConsultarPlatilloMediator>();

        services.AddTransient<IComandaDtoMapper, ComandaDtoMapper>();
        return services;
    }
}

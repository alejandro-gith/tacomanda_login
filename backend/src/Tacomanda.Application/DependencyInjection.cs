using Microsoft.Extensions.DependencyInjection;
using Tacomanda.Application.Respuestas;
using Tacomanda.Application.Validacion;
using Tacomanda.Application.CrearComanda;
using Tacomanda.Application.InicioSesion;
using Tacomanda.Application.AltaEmpleado;
using Tacomanda.Application.CrearPlatillo;
using Tacomanda.Application.EditarPlatillo;
using Tacomanda.Application.EliminarPlatillo;
using MediatR;
using AutoMapper;

namespace Tacomanda.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(ConfigurarMediatR);
        services.AddAutoMapper(ConfigurarAutoMapper, typeof(ComandaMappingProfile));
        services.AddTransient<IValidator<IniciarSesionCommand>, IniciarSesionValidator>();
        services.AddTransient<IValidator<CrearComandaCommand>, CrearComandaValidator>();
        services.AddTransient<IValidator<AltaEmpleadoCommand>, AltaEmpleadoValidator>();
        services.AddTransient<IValidator<CrearPlatilloCommand>, CrearPlatilloValidator>();
        services.AddTransient<IValidator<EditarPlatilloCommand>, EditarPlatilloValidator>();
        services.AddTransient<IValidator<EliminarPlatilloCommand>, EliminarPlatilloValidator>();
        return services;
    }

    private static void ConfigurarMediatR(MediatRServiceConfiguration configuration)
    {
        configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
    }

    private static void ConfigurarAutoMapper(IMapperConfigurationExpression configuration)
    {
        configuration.LicenseKey = Environment.GetEnvironmentVariable("AUTOMAPPER_LICENSE_KEY");
    }
}

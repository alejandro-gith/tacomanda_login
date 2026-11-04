using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Tacomanda.Api.Contracts;

namespace Tacomanda.Api.Configuration;

public sealed class ApiBehaviorConfiguration : IConfigureOptions<ApiBehaviorOptions>
{
    public void Configure(ApiBehaviorOptions options)
    {
        options.InvalidModelStateResponseFactory = CrearRespuesta;
    }

    private static IActionResult CrearRespuesta(ActionContext context)
    {
        ILogger<ApiBehaviorConfiguration> logger = context.HttpContext.RequestServices
            .GetRequiredService<ILogger<ApiBehaviorConfiguration>>();
        logger.LogWarning("JSON o contrato HTTP inválido. TraceId: {TraceId}",
            context.HttpContext.TraceIdentifier);

        return new BadRequestObjectResult(
            new ErrorResponse(400, "Error en el sistema.", context.HttpContext.TraceIdentifier));
    }
}

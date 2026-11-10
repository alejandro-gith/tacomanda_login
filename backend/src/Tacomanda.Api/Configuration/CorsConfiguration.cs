using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;

namespace Tacomanda.Api.Configuration;

public sealed class CorsConfiguration : IConfigureOptions<CorsOptions>
{
    public void Configure(CorsOptions options)
    {
        CorsPolicy policy = new CorsPolicyBuilder()
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .Build();

        options.AddDefaultPolicy(policy);
    }
}

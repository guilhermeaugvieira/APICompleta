using DevIO.API.Extensions;
using Elmah.Io.AspNetCore.HealthChecks;
using Elmah.Io.Extensions.Logging;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DevIO.API.Configurations
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "4f6ed29e46f54a5e93f157eeabfc68e1";
                o.LogId = new Guid("d23ed917-769e-4ad2-8aef-49dad2e5b045");
            });

            //services.AddLogging(builder =>
            //{
            //    builder.AddElmahIo(o =>
            //    {
            //        o.ApiKey = "4f6ed29e46f54a5e93f157eeabfc68e1";
            //        o.LogId = new Guid("d23ed917-769e-4ad2-8aef-49dad2e5b045");  //Loga tudo
            //    });

            //    builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            //});

            services.AddHealthChecks()
                .AddElmahIoPublisher("4f6ed29e46f54a5e93f157eeabfc68e1", new Guid("d23ed917-769e-4ad2-8aef-49dad2e5b045"), "Api Completa")
                .AddCheck("Produtos", new SQLServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "bancoSQL");

            services.AddHealthChecksUI();

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            app.UseHealthChecks("/api/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options => {
                options.UIPath = "/api/hc-ui";
            });

            return app;
        }
    }
}

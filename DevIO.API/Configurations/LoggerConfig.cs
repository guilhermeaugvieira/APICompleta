using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DevIO.API.Configurations
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services)
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

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();
            
            return app;
        }
    }
}

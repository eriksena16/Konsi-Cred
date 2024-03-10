using KonsiCred.Api.IoC;
using KonsiCred.Facade;

namespace KonsiCred.Api.ApiConfig
{
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfig(this WebApplicationBuilder builder)
        {
            builder.Configuration
                    .SetBasePath(builder.Environment.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                    .AddEnvironmentVariables();

            builder.Services.AddControllers()
                            .ConfigureApiBehaviorOptions(options =>
                            {
                                options.SuppressModelStateInvalidFilter = true;
                            });
            builder.Services.RegisterServices();
            builder.Services.ConfigureRabbitMqServices(builder.Configuration);
            builder.Services.ConfigureRedisServices(builder.Configuration);

            builder.Services.AddHttpClient(KonsiExternalOptions.Instance, options =>
            {
            });
            builder.Services.Configure<KonsiExternalOptions>(builder.Configuration.GetSection(nameof(KonsiExternalOptions)));

         

            return builder;
        }
    }
}

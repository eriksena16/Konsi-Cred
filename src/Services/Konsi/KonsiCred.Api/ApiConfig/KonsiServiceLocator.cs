using KonsiCred.Application;
using KonsiCred.Application.Services;
using KonsiCred.Core;
using KonsiCred.Data;
using KonsiCred.Domain;
using KonsiCred.Facade;

namespace KonsiCred.Api.IoC
{
    public static class KonsiServiceLocator
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IUsuarioKonsiFacade, UsuarioKonsiService>();
            services.AddScoped<IClienteKonsiFacade, ClienteKonsiService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IRabbitMQService, RabbitMQService>();
            services.AddHostedService<ConsumidorFilaService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddDistributedMemoryCache();

            #endregion

            services.AddScoped<ICacheRepository, CacheRepository>();
        }
    }
}

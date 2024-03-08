using KonsiCred.Application;
using KonsiCred.Application.Services;
using KonsiCred.Core;
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

            services.AddHostedService<ConsumerService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddScoped<IDepartamentoService, DepartamentoService>();

            #endregion
        }
    }
}

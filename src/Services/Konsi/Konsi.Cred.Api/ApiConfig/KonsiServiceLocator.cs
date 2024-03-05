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
            services.AddScoped<INotifier, Notifier>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddScoped<IDepartamentoService, DepartamentoService>();

            #endregion

            #region Repositories 
            //services.AddScoped<PatrimonioContext>();
            //services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

            #endregion 
        }
    }
}

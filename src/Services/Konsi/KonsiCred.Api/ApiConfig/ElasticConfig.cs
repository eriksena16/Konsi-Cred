using KonsiCred.Application;
using KonsiCred.Application.Services;
using Nest;

namespace KonsiCred.Api.ApiConfig
{
    public static class ElasticConfig
    {
        public static void ConfigureElasticServices(this IServiceCollection services, IConfiguration configuration)
        {
            var cfgEndpoint = configuration["Elastic:Endpoint"];

            var uriBuilder = new UriBuilder(cfgEndpoint)
            {
            };
            #region Services
            try
            {
                var setting = new ConnectionSettings(uriBuilder.Uri)
                    .DefaultMappingFor<ClienteDTO>(x => x.IndexName("konsicred"));


                var client = new ElasticClient(setting);

                services.AddSingleton(client);
                services.AddSingleton<IElasticClient>(client);
            }
            catch { }

            #endregion 
        }
    }
}

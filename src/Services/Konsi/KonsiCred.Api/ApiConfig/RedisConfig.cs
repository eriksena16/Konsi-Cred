using RabbitMQ.Client;

namespace KonsiCred.Api.ApiConfig
{
    public static class RedisConfig
    {
        public static void ConfigureRedisServices(this IServiceCollection services, IConfiguration configuration)
        {
            var cfgEndpoint = configuration["Redis:Endpoint"];
            var cfgPassword = configuration["Redis:Password"];


            #region Services
            try
            {
                services.AddStackExchangeRedisCache(options =>
                {
                    options.InstanceName = "RedisKonsiCred";
                    options.Configuration = cfgEndpoint;
                    options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions { Password = cfgPassword };
                    options.ConfigurationOptions.EndPoints.Add(cfgEndpoint);
                    options.ConfigurationOptions.ConnectTimeout = 1000;

                });
            }
            catch { }

            #endregion 
        }
    }
}

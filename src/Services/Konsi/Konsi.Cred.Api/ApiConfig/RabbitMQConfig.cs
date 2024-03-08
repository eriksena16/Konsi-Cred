using RabbitMQ.Client;

namespace KonsiCred.Api.ApiConfig
{
    public static class RabbitMQConfig
    {
        public static void ConfigureRabbitMqServices(this IServiceCollection services, IConfiguration configuration)
        {
            var factory = new ConnectionFactory
            {
                HostName = configuration["RabbitMQ:HostName"],
                UserName = configuration["RabbitMQ:UserName"],
                Password = configuration["RabbitMQ:Password"]
            };
            factory.AutomaticRecoveryEnabled = true;
            #region Services
            try
            {
                services.AddSingleton(sp => factory.CreateConnection());
                services.AddScoped(sp => sp.GetRequiredService<IConnection>().CreateModel());
            }
            catch {}

            #endregion 
        }
    }
}

using KonsiCred.Application;


namespace KonsiCred.Api.ApiConfig
{
    public static class RabbitMqBuider
    {
        public static IApplicationBuilder UseRabbitMq(
           this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var rabbitMQService = scope.ServiceProvider.GetRequiredService<IRabbitMQService>();

                rabbitMQService.EnqueueCpfs();

            }

            return app;
        }
    }
}

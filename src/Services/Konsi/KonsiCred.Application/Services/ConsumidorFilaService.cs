﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace KonsiCred.Application
{
    public class ConsumidorFilaService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IModel _channel;
        private IConnection _connection;
        public ConsumidorFilaService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            InitializeRabbitMQConnection(serviceProvider);
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: "cpf-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += async (model, ea) =>
                {
                    var cpfReceived = Encoding.UTF8.GetString(ea.Body.ToArray());

                    BuscarBeneficio(cpfReceived).Wait();

                    //_channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                _channel.BasicConsume(queue: "cpf-queue",
                                     autoAck: true,
                                     consumer: consumer);

            }
            return Task.CompletedTask;
        }

        private async Task BuscarBeneficio(string cpfString)
        {
            using var scope = _serviceProvider.CreateScope();
            var cpf = new CpfDTO(cpfString);
            var clienteService = scope.ServiceProvider.GetService<IClienteService>();

            var cliente = await clienteService.BuscarCliente(cpf);
        }
        private void InitializeRabbitMQConnection(IServiceProvider serviceProvider)
        {
            _connection = serviceProvider.GetRequiredService<IConnection>();
        }

    }
}

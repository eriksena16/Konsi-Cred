﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace KonsiCred.Application
{
    public class ConsumerService : BackgroundService
    {
        private  IServiceProvider _serviceProvider;
        private readonly IModel _channel;
        private readonly IConnection _connection;
        public ConsumerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: "cpf-queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
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

                };
                _channel.BasicConsume(queue: "cpf-queue",
                                     autoAck: true,
                                     consumer: consumer);

            }
            return Task.CompletedTask;
        }

        private async Task BuscarBeneficio(string cpf)
        {
            using var scope = _serviceProvider.CreateScope();

            var clienteService = scope.ServiceProvider.GetService<IClienteService>();

            var cliente = await clienteService.BuscarPorCpf(cpf);
        }

    }
}

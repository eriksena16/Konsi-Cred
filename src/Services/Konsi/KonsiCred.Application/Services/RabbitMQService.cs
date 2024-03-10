using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace KonsiCred.Application
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IModel _channel;
        public RabbitMQService(IModel channel)
        {
            _channel = channel;
            _channel.QueueDeclare(queue: "cpf-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
        }

        public void EnqueueCpfs()
        {
            var cpfs = new List<string>
            {
                "343.228.350-40",
                "869.230.000-41",
                "568.946.870-30",
                "433.510.120-12",
                "415.022.590-79",
            };

            foreach (string cpf in cpfs)
            {
                EnqueueCpf(cpf);
            }
        }

        private void EnqueueCpf(string cpf)
        {
            var body = Encoding.UTF8.GetBytes(cpf);

            for (int i = 0; i < 2; i++)
            {
                _channel.BasicPublish(exchange: "", routingKey: "cpf-queue", basicProperties: null, body: body);
            }
        }
    }
}

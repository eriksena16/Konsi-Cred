using RabbitMQ.Client;

namespace KonsiCred.Application
{
    public interface IRabbitMQService
    {
        void EnqueueCpfs();
    }
}

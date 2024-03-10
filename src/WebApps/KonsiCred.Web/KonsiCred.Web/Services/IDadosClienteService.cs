using KonsiCred.Application;

namespace KonsiCred.Web
{
    public interface IDadosClienteService
    {
        Task<HttpResponseMessage> GetCliente(ClienteDTQ cliente);
    }
}
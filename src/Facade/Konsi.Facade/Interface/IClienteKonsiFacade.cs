using KonsiCred.Domain;

namespace KonsiCred.Facade
{
    public interface IClienteKonsiFacade
    {
        Task<Response<Cliente>> ObterPorCpf(long cpf);
    }
}

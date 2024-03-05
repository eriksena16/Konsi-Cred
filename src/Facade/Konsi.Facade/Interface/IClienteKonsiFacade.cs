using KonsiCred.Domain.Entities;

namespace KonsiCred.Facade
{
    public interface IClienteKonsiFacade
    {
        Task<Response<Cliente>> ObterPorCpf(long cpf);
    }
}

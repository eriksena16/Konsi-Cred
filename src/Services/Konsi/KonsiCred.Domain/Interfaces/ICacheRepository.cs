using System.Threading.Tasks;

namespace KonsiCred.Domain
{
    public interface ICacheRepository
    {
        Task<T> ObterValor<T>(string cpf);
        Task InserirValor<T>(string cpf, T obj);
    }
}

using KonsiCred.Core;

namespace KonsiCred.Application.Services
{
    public class ClienteService : ServiceBase, IClienteService
    {
        
        public ClienteService(INotifier notifier) : base(notifier)
        {
         
        }

        public Task<ClienteDTO> BuscarPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }



        //public void Dispose()
        //{
        //    _categoriaRepository?.Dispose();
        //}
    }
}

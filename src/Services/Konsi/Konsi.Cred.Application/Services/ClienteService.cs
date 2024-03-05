using KonsiCred.Core;
using KonsiCred.Facade;

namespace KonsiCred.Application.Services
{
    public class ClienteService : ServiceBase, IClienteService
    {
        private readonly IClienteKonsiFacade _clienteKonsi;
        public ClienteService(INotifier notifier, IClienteKonsiFacade clienteKonsi) : base(notifier)
        {
            _clienteKonsi = clienteKonsi;
        }

        public async Task<ClienteDTO> BuscarPorCpf(long cpf)
        {
            try
            {
                var response = await _clienteKonsi.ObterPorCpf(cpf);

                if (!response.Success)
                    Notificar(response.Observations);

                var clienteDto = AutoMapperCliente.ParaClienteDTO(response.Data);
            
                return clienteDto;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }



        //public void Dispose()
        //{
        //    _categoriaRepository?.Dispose();
        //}
    }
}

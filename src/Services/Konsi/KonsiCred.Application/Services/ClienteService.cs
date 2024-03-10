using KonsiCred.Core;
using KonsiCred.Domain;
using KonsiCred.Facade;

namespace KonsiCred.Application.Services
{
    public class ClienteService : ServiceBase, IClienteService
    {
        private readonly IClienteKonsiFacade _clienteKonsi;
        private readonly ICacheRepository _cacheRepository;
        public ClienteService(INotifier notifier, IClienteKonsiFacade clienteKonsi, ICacheRepository cacheRepository) : base(notifier)
        {
            _clienteKonsi = clienteKonsi;
            _cacheRepository = cacheRepository;
        }

        public async Task<ClienteDTO> BuscarClienteKonsi(string cpf)
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

        public async Task<ClienteDTO> BuscarCliente(CpfDTO cpf)
        {
            cpf.ValidarCPF();
            var cliente = await _cacheRepository.ObterValor<ClienteDTO>(cpf.ToString());

            if (cliente is null)
            {
                cliente = await BuscarClienteKonsi(cpf.ToString());
                await _cacheRepository.InserirValor(cpf.ToString(), cliente);
            }

            return cliente;

        }
    }
}

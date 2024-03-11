using KonsiCred.Core;
using KonsiCred.Domain;
using KonsiCred.Facade;
using Nest;

namespace KonsiCred.Application.Services
{
    public class ClienteService : ServiceBase, IClienteService
    {
        private readonly IClienteKonsiFacade _clienteKonsi;
        private readonly ICacheRepository _cacheRepository;
        private readonly ElasticClient _elasticClient;
        public ClienteService(INotifier notifier, IClienteKonsiFacade clienteKonsi, ICacheRepository cacheRepository, ElasticClient elasticClient) : base(notifier)
        {
            _clienteKonsi = clienteKonsi;
            _cacheRepository = cacheRepository;
            _elasticClient = elasticClient;
        }

        public async Task<ClienteDTO> BuscarClienteKonsi(string cpf)
        {
            try
            {
                var response = await _clienteKonsi.ObterPorCpf(cpf);

                if (!response.Success)
                    Notificar(response.Observations);

                return response.Data != null ? AutoMapperCliente.ParaClienteDTO(response.Data) : default;
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
                if (cliente is not null)
                {
                    await _cacheRepository.InserirValor(cpf.ToString(), cliente);

                   await _elasticClient.IndexDocumentAsync(cliente);
                }
                    
            }

            return cliente;

        }
    }
}

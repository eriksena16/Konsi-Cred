using Konsi.Core;
using KonsiCred.Core;
using Nest;

namespace KonsiCred.Application.Services
{
    public class ElasticsearchService(INotifier notifier, ElasticClient elasticClient) : ServiceBase(notifier), IElasticsearchService
    {
        private readonly IElasticClient _elasticClient = elasticClient;

        public async Task<bool> CriarDocumentoAsync(ClienteDTO documento)
        {
            var response = await _elasticClient.IndexDocumentAsync(documento);

            return response.IsValid;
        }

        public async Task<ClienteDTO> ObterDocumentoAsync(string cpf)
        {
            var response = await _elasticClient.SearchAsync<ClienteDTO>(s => s
                .Query(q => q
                .Match(m => m
                .Field(f => f.Cpf)
                .Query(cpf)
         )));
            var cliente = response?.Hits?.FirstOrDefault()?.Source;

            if (cliente == null)
            {
                Notificar($"{KonsiErrorMessages.ERROR_CLIENTE_NOT_FOUND}{cpf}");
            }

            return cliente;
        }

    }
}

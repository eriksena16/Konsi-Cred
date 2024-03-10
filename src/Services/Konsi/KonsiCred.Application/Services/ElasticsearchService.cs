using Nest;

namespace KonsiCred.Application.Services
{
    public class ElasticsearchService<T> : IElasticsearchService<T> where T : class
    {
        private readonly ElasticClient _elasticClient;
        public ElasticsearchService(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task<bool> CriarDocumentoAsync(T documento)
        {
           var response = await _elasticClient.IndexDocumentAsync(documento);

            return response.IsValid;
        }

        public async Task<T> ObterDocumentoAsync(string cpf)
        {
            var response = await _elasticClient.GetAsync( new DocumentPath<T>(cpf));

            return response.Source;
        }
    }
}

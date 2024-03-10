using KonsiCred.Application;
using Microsoft.Extensions.Options;

namespace KonsiCred.Web
{
    public class DadosClienteService : IDadosClienteService
    {
        private readonly KonsiCredOptions _konsiCredOptions;
        private HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        public DadosClienteService(IOptionsMonitor<KonsiCredOptions> konsiCredOptions, HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _konsiCredOptions = konsiCredOptions.CurrentValue;
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<HttpResponseMessage> GetCliente(ClienteDTQ clienteDtq)
        {
            string requestUri = string.Format(_konsiCredOptions.RequestUriConsultaBeneficio, clienteDtq.Cpf);

            _httpClient = _httpClientFactory.CreateClient(KonsiCredOptions.Instance);
            _httpClient.BaseAddress = new Uri(_konsiCredOptions.BaseAddress);

            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(requestUri);
            
            return httpResponseMessage;
        }
    }
}

using KonsiCred.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KonsiCred.Facade
{
    public class ClienteKonsiService : IClienteKonsiFacade
    {
        private readonly KonsiExternalOptions _konsiOptions;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _contextAccessor;
        private HttpClient _httpClient;
        public ClienteKonsiService(IOptionsMonitor<KonsiExternalOptions> optionsMonitor, HttpClient httpClient, IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor)
        {

            _konsiOptions = optionsMonitor.CurrentValue;
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
            _contextAccessor = contextAccessor;
        }

        public async Task<Response<Cliente>> ObterPorCpf(long cpf)
        {
            string requestUri = string.Format(_konsiOptions.RequestUriCliente, cpf);
            _httpClient = _httpClientFactory.CreateClient(KonsiExternalOptions.Instance);
            _httpClient.BaseAddress = new Uri(_konsiOptions.BaseAddress);
            ObterToken();

            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(requestUri);
            string jsonContent = await httpResponseMessage.Content.ReadAsStringAsync();

            var cliente = JsonConvert.DeserializeObject<Response<Cliente>>(jsonContent);

            return cliente;
        }

        private void ObterToken()
        {
            if (_contextAccessor.HttpContext?.Request.Headers.TryGetValue("Authorization", out var auth) == true
        && !_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
               
                _httpClient.DefaultRequestHeaders.Add("Authorization", "" + auth);

            }
        }
    }



    //public class ClienteDTO
    //{
    //    public ClienteDTO()
    //    {
    //        Beneficios = new List<Beneficio>();
    //    }
    //    public string Cpf { get; set; }
    //    public List<Beneficio> Beneficios { get; set; }
    //}



  
}

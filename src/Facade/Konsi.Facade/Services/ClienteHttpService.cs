//using Blazored.LocalStorage;
//using Konsi.Facade.Services;
//using Microsoft.Extensions.Options;
//using System.Net.Http.Json;

//namespace KonsiCred.Facade
//{
//    public class ClienteHttpService : IClienteHttpService
//    {
//        private readonly KonsiCredOptions _konsiLocationOptions;
//        private readonly IHttpClientBase _httpClientBase;
//        public ILocalStorageService _localStorageService { get; }
//        public ClienteHttpService(IOptionsMonitor<KonsiCredOptions> patrimonioLocationOptions, IHttpClientBase httpClient)
//        {

//            _konsiLocationOptions = patrimonioLocationOptions.CurrentValue;
//            _httpClientBase = httpClient;
//        }

//        public async Task<ClienteDTO> ObterPorCpf(long cpf)
//        {
//            string requestUri = string.Format(_konsiLocationOptions.RequestUriKonsiApi, cpf);
//            HttpClient httpClient = await _httpClientBase.ObterHttpClient(KonsiCredOptions.Instance, _konsiLocationOptions.BaseAddress);

//            var cliente = await httpClient.GetFromJsonAsync<ClienteDTO>(requestUri);
             
//            return cliente;
//        }
//    }

//    public class ClienteDTO
//    {
//        public long Id { get; set; }
//    }
//}

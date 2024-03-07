using KonsiCred.Application;
using KonsiCred.Core;
using KonsiCred.Domain;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace KonsiCred.Facade
{
    public class ClienteKonsiService : IClienteKonsiFacade
    {
        private readonly KonsiExternalOptions _konsiOptions;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUsuarioKonsiFacade _usuario;
        private HttpClient _httpClient;

        public ClienteKonsiService(IOptionsMonitor<KonsiExternalOptions> optionsMonitor, HttpClient httpClient, IHttpClientFactory httpClientFactory, IUsuarioKonsiFacade usuario)
        {

            _konsiOptions = optionsMonitor.CurrentValue;
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
            _usuario = usuario;
        }

        public async Task<Response<Cliente>> ObterPorCpf(long cpf)
        {
            string requestUri = string.Format(_konsiOptions.RequestUriCliente, cpf);

            await CriarHttpClient();

            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(requestUri);
            string jsonContent = await httpResponseMessage.Content.ReadAsStringAsync();

            var cliente = JsonConvert.DeserializeObject<Response<Cliente>>(jsonContent);

            return cliente;
        }

        private async Task CriarHttpClient()
        {
            _httpClient = _httpClientFactory.CreateClient(KonsiExternalOptions.Instance);
            _httpClient.BaseAddress = new Uri(_konsiOptions.BaseAddress);

            await Login();
        }
        private async Task Login()
        {
            var login = new LoginUser()
            {
                username = _konsiOptions.UserName.Decrypt(),
                password = _konsiOptions.PassWord.Decrypt(),
            };
            var token = await _usuario.LoginAsync(login);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token?.Data?.Type, token?.Data?.Token);
        }
    }
}

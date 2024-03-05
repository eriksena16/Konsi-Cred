using KonsiCred.Application;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace KonsiCred.Facade
{
    public class UsuarioKonsiService : IUsuarioKonsiFacade
    {

        private readonly KonsiExternalOptions _konsiOptions;
        private readonly IHttpClientFactory _httpClientFactory;
        public UsuarioKonsiService(IHttpClientFactory httpClientFactory,
            IOptionsMonitor<KonsiExternalOptions> optionsMonitor
            )
        {
            _httpClientFactory = httpClientFactory;
            _konsiOptions = optionsMonitor.CurrentValue;

        }

        public async Task<BearerToken> LoginAsync(LoginUser user)
        {
            var requestContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            HttpClient httpClient = _httpClientFactory.CreateClient(KonsiExternalOptions.Instance);
            httpClient.BaseAddress = new Uri(_konsiOptions.BaseAddress);

            var response = await httpClient.PostAsync(_konsiOptions.RequestUriToken, requestContent);

            var bearerToken =  await response.Content.ReadFromJsonAsync<BearerToken>();

            return bearerToken;

        }
    }
}

using Blazored.LocalStorage;
using Microsoft.JSInterop;
using System.Net.Http.Headers;

namespace Konsi.Facade.Services
{
    public class HttpClientBase : IHttpClientBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;
        public ILocalStorageService _localStorageService { get; }
        private readonly IJSRuntime _jSRuntime;
        public HttpClientBase(IHttpClientFactory httpClientFactory, HttpClient httpClient, ILocalStorageService localStorageService, IJSRuntime jSRuntime)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _jSRuntime = jSRuntime;
        }

        public async Task<HttpClient> ObterHttpClient(string instance, string baseAddres)
        {
            string token = string.Empty;
            try
            {
                token = await _localStorageService.GetItemAsync<string>("accessToken");
            }
            catch (InvalidOperationException)
            {
            }
            _httpClient = _httpClientFactory.CreateClient(instance);
            _httpClient.BaseAddress = new Uri(baseAddres);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return _httpClient;
        }
        public async Task AdicionarUserAgent(HttpClient httpClient)
        {
            var remoteUserAgent = await _jSRuntime.InvokeAsync<string>("getUserAgent");
            httpClient.DefaultRequestHeaders.Add("User-Agent", remoteUserAgent);
        }
    }
}

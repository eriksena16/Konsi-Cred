namespace Konsi.Facade.Services
{
    public interface IHttpClientBase
    {
        Task<HttpClient> ObterHttpClient(string instance, string baseAddres);
        Task AdicionarUserAgent(HttpClient httpClient);
    }
}

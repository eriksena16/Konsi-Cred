using KonsiCred.Application;

namespace KonsiCred.Facade
{
    public interface IUsuarioKonsiFacade
    {
        Task<BearerToken> LoginAsync(LoginUser user);
        //Task<BearerToken> ObterPorAccessToken(string accessToken);
    }
}

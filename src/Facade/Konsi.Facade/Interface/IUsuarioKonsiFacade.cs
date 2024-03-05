using KonsiCred.Application;

namespace KonsiCred.Facade
{
    public interface IUsuarioKonsiFacade
    {
        Task<BearerToken> LoginAsync(LoginUserDTO user);
        //Task<BearerToken> ObterPorAccessToken(string accessToken);
    }
}

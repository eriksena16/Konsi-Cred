using System.Security.Claims;

namespace Konsi.Core
{
    public interface IUsuario
    {
        string Name { get; }
        string GetUserId();
        long GetAccountId();
        string GetUserEmail();
        bool IsAuthenticated();
        string GetLocalIpAddress();
        string GetRemoteIpAddress();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}

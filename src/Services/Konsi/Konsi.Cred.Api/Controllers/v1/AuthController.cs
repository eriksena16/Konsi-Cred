using KonsiCred.Application;
using KonsiCred.Core;
using KonsiCred.Facade;
using Microsoft.AspNetCore.Authorization;

namespace Patrimony.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private readonly IUsuarioKonsiFacade _usuario;
        public AuthController(INotifier notifier, IUsuarioKonsiFacade usuarioKonsiFacade) : base(notifier)
        {
            _usuario = usuarioKonsiFacade;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUser)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var result = await _usuario.LoginAsync(loginUser);

            return Ok(result);

        }


    }
}

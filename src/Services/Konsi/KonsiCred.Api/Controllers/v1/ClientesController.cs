using KonsiCred.Application;
using KonsiCred.Core;
using KonsiCred.Facade;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Patrimony.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClientesController : ApiControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(INotifier notifier, IClienteService clienteService) : base(notifier)
        {
            _clienteService = clienteService;
        }

        [HttpGet("consulta-beneficios")]
        [ProducesResponseType(typeof(ClienteDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarCliente([FromQuery][Required] string cpf)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var cliente = await _clienteService.BuscarCliente(new CpfDTO(cpf));

            return Ok(cliente);
        }
    }
}

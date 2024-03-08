using KonsiCred.Core;
using KonsiCred.Facade;
using System.Net;

namespace Patrimony.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClientesController : ApiControllerBase
    {
        private readonly IClienteKonsiFacade _clienteKonsi;

        public ClientesController(INotifier notifier, IClienteKonsiFacade clienteKonsi) : base(notifier)
        {
            _clienteKonsi = clienteKonsi;
        }

        [HttpGet("consulta-beneficios")]
        [ProducesResponseType(typeof(ClienteDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterPorId([FromQuery] string cpf)
        {
           var teste = await _clienteKonsi.ObterPorCpf(cpf); return Ok(teste);
        }


        //private async Task<ClienteDTO> ObterClienteDto(long id) => AutoMapperCliente.ParaClienteDTO(await _categoriaRepository.ObterPorIdAsNoTracking(id));
    }
}

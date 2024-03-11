using KonsiCred.Application;
using KonsiCred.Core;
using KonsiCred.Domain;
using KonsiCred.Facade;
using Nest;
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
        private readonly IElasticsearchService _elasticClient;

        public ClientesController(INotifier notifier, IClienteService clienteService, IElasticsearchService elasticClient) : base(notifier)
        {
            _clienteService = clienteService;
            _elasticClient = elasticClient;
        }

        [HttpGet("consulta-beneficios")]
        [ProducesResponseType(typeof(ClienteDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarCliente([FromQuery][Required] string cpf)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var cliente = await _elasticClient.ObterDocumentoAsync(cpf);

            return CustomResponse(cliente);
        }
    }
}

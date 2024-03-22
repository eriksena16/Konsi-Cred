using KonsiCred.Application;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace KonsiCred.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClientesController : ApiControllerBase
    {
        private readonly IElasticsearchService _elasticClient;

        public ClientesController(INotifier notifier, IElasticsearchService elasticClient) : base(notifier)
        {
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

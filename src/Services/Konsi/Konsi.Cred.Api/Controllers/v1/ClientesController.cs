//using KonsiCred.Application;
//using KonsiCred.Core;
//using Microsoft.AspNetCore.Authorization;
//using Newtonsoft.Json;
//using System.Net;

//namespace Patrimony.Api.Controllers
//{
//    [Authorize]
//    [ApiVersion("1.0")]
//    [Route("api/v{version:apiVersion}/[controller]")]
//    [ApiController]
//    public class ClientesController : ApiControllerBase
//    {
//        private readonly IClienteService _categoriaService;

//        public ClientesController(IClienteService categoriaService, INotifier notifier) : base(notifier)
//        {
//            _categoriaService = categoriaService;
//        }

//        [HttpGet("buscar-cliente={cpf}")]
//        [ProducesResponseType(typeof(ClienteDTO), (int)HttpStatusCode.OK)]
//        public async Task<ActionResult<ClienteDTO>> ObterPorId(long cpf)
//              => await ObterClienteDto(id);
        

//        //private async Task<ClienteDTO> ObterClienteDto(long id) => AutoMapperCliente.ParaClienteDTO(await _categoriaRepository.ObterPorIdAsNoTracking(id));
//    }
//}

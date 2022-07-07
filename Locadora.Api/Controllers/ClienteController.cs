using Locadora.Application.Services.Interfaces;
using Locadora.Application.ViewModels.ClientesViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarCliente() 
        {
            var cliente = await _clienteAppService.ListarCliente();
            if(cliente == null) return NotFound("nenhum Cliente encontrado");
            return Ok(cliente);
        }
        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> ClienteId(long id) 
        {
            var cliente = await _clienteAppService.ClienteId(id);
            if(cliente == null) return NotFound("nenhum Cliente encontrado");
            return Ok(cliente);
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarCliente([FromBody] NovoClienteViewModel vm) 
        {
            var result = await _clienteAppService.CadastrarCliente(vm);
            if(result == null) return BadRequest("não foi possivel cadastrar o Cliente");
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> AtualizarCliente([FromBody] AtualizarClienteViewModel vm) 
        {
            var result = await _clienteAppService.AtualizarCliente(vm);
            if (result == null) return BadRequest("não foi possivel atualizar o Cliente");
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletarCliente(long id) 
        {
            var result = await _clienteAppService.DeletarCliente(id);
            if (!result) return BadRequest($" não foi possivel excluir Cliente{id}");
            if (result) return Ok();
            return NotFound();
        }
    }
}

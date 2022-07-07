
using Locadora.Application.Services.Interfaces;
using Locadora.Application.ViewModels.LocacaoViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoAppService _locacaoAppService;
        public LocacaoController(ILocacaoAppService locacaoAppService)
        {
            _locacaoAppService = locacaoAppService;
        }
        [HttpGet]
        public async Task<IActionResult> Listarlocacao()
        {
            var locacao = await _locacaoAppService.Listarlocacao();
            if (locacao == null) return NotFound("Nenhum locação encontrado");
            return Ok(locacao);
        }
        [HttpGet]
        [Route("{data}")]
        public async Task<IActionResult> DataLocacao(DateTime data)
        {
            var locacao = await _locacaoAppService.DataLocacao(data);
            if (locacao == null) return NotFound("Nenhum locação encontrado");
            return Ok(locacao);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarLocacao([FromBody] NovaLocacaoViewModel vm)
        {
            var result = await _locacaoAppService.CadastrarLocacao(vm);
            if (result == null) return BadRequest("não foi possivel cadastrar o Locação");
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> AtualizarLocacao([FromBody] AtualizarLocacaoViewModel vm)
        {
            var result = await _locacaoAppService.AtualizarLocacao(vm);
            if (result == null) return BadRequest("não foi possivel Atualizar o Locação");
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletarLocacao(long id)
        {
            var result = await _locacaoAppService.DeletarLocacao(id);
            if (!result) return BadRequest($"Não foi possível excluir Locação {id}");
            if (result) return Ok();
            return NotFound();
        }
    }
}

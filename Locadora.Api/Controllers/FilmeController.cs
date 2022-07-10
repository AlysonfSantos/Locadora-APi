using Locadora.Application.Services.Interfaces;
using Locadora.Application.ViewModels.FilmesViewModel;
using Locadora.Application.ViewModels.UploadArquivosViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeAppService _filmeAppService;

        public FilmeController(IFilmeAppService filmeAppService)
        {
            _filmeAppService = filmeAppService;
        }
        [HttpGet]
        public async Task<IActionResult> ListaFilme()
        {
            var filme = await _filmeAppService.ListarFilme();
            if (filme == null) return NotFound("Nenhum Filme encontrado");
            return Ok(filme);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> FilmeId(long id) 
        {
            var filme = await _filmeAppService.FilmeId(id);
            if (filme == null) return NotFound("Nenhum Filme encontrado");
            return Ok(filme);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarFilme([FromBody] NovoFilmeViewModel vm) 
        {
            var result = await _filmeAppService.CadastrarFilme(vm);
            if (result == null) return BadRequest("não foi possivel cadastrar o filme");
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> AtualizarFilme([FromBody] AtualizarFilmeViewModel vm)
        {
            var result = await _filmeAppService.AtualizarFilme(vm);
            if (result == null) return BadRequest("não foi possivel Atualizar o filme");
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletarFilme(long id) 
        {
            var result = await _filmeAppService.DeletarFilme(id);
            if (!result) return BadRequest($"Não foi possível excluir Filme {id}");
            if (result) return Ok();
            return NotFound();
        }

        [Consumes(contentType: "multipart/form-data")]
        [HttpPost(template: "input-file")]
        public async Task<IActionResult> ImportarArquivo(IFormFile file) 
        {
            var result =  await   _filmeAppService.ImportarArquivo(file);
            if (result == null) return BadRequest("não foi possivel cadastrar arquivo de filme");

            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinaAPIRest.Models;
using ProjetoFinaAPIRest.Services;

namespace ProjetoFinaAPIRest.Controllers
{
    [Route("api")]
    [ApiController]
    public class PessoasController : ControllerBase
    {

        private readonly PessoaService _pessoaService;

        public PessoasController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        [Route("pessoa")]
        public async Task<IActionResult> getAllAsync()
        {
            var list = await _pessoaService.FindAllAsync();
            return list == null ? NotFound() : Ok(list);

        }
        [HttpGet]
        [Route("pessoa/{id}")]
        public async Task<IActionResult> getByIdAsync([FromRoute] int id)
        {
            var pessoa = await _pessoaService.FindByIdAsync(id);
            return pessoa == null ? NotFound() : Ok(pessoa);
        }

        [HttpPost]
        [Route("pessoa")]
        public async Task<IActionResult> PostAsync(
           [FromBody] Pessoa pessoa
           
            )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _pessoaService.InsertAsync(pessoa);
                return Created($"api/localevento/{pessoa.Id}", pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut]
        [Route("pessoa/{id}")]
        public async Task<IActionResult> PutAsync(
         [FromBody] Pessoa pessoa,
         [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var p = await _pessoaService.FindByIdAsync(id);
            if (p == null)
                return NotFound();

            try

            {
                p.Nome = pessoa.Nome;
                p.DataNascimento = pessoa.DataNascimento;
                p.Cpf = pessoa.Cpf;
                p.RG = pessoa.RG;


                await _pessoaService.UpdateAsync(p);

                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("pessoa/{id}")]
        public async Task<IActionResult> DeletAsync(
           [FromRoute] int id
            )
        {
            var pessoa = await _pessoaService.FindByIdAsync(id);
            if (pessoa == null)
                return NotFound();

            try
            {

                await _pessoaService.RemoveAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}


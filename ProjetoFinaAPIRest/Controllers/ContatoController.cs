using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinaAPIRest.Models;
using ProjetoFinaAPIRest.Services;

namespace ProjetoFinaAPIRest.Controllers
{
    [Route("api")]
    [ApiController]
    public class ContatoController : ControllerBase
    {

        private readonly ContatoService _contatoService;

        public ContatoController(ContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [Authorize]
        [HttpGet]
        [Route("contato")]
        public async Task<IActionResult> getAllAsync()
        {
            var list = await _contatoService.FindAllAsync();
            return list == null ? NotFound() : Ok(list);

        }
        [Authorize]
        [HttpGet]
        [Route("contato/{id}")]
        public async Task<IActionResult> getByIdAsync([FromRoute] int id)
        {
            var contato = await _contatoService.FindByIdAsync(id);
            return contato == null ? NotFound() : Ok(contato);
        }
        [Authorize]
        [HttpPost]
        [Route("contato")]
        public async Task<IActionResult> PostAsync(
           [FromBody] Contato contato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _contatoService.InsertAsync(contato);
                return Created($"api/localevento/{contato.Id}", contato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [Authorize]
        [HttpPut]
        [Route("contato/{id}")]
        public async Task<IActionResult> PutAsync(
         [FromBody] Contato contato,
         [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var c = await _contatoService.FindByIdAsync(id);
            if (c == null)
                return NotFound();

            try

            {
                c.Telefone = contato.Telefone;
                c.Email = contato.Email;
                c.PessoaId = contato.PessoaId;
               
                await _contatoService.UpdateAsync(c);

                return Ok(c);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [Authorize]
        [HttpDelete]
        [Route("contato/{id}")]
        public async Task<IActionResult> DeletAsync(
           [FromRoute] int id
            )
        {
            var contato = await _contatoService.FindByIdAsync(id);
            if (contato == null)
                return NotFound();

            try
            {

                await _contatoService.RemoveAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

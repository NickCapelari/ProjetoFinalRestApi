using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinaAPIRest.Models;
using ProjetoFinaAPIRest.Services;

namespace ProjetoFinaAPIRest.Controllers
{
    [Route("api")]
    [ApiController]
    public class IngressoController : ControllerBase
    {
        private readonly IngressoService _ingresso;

        public IngressoController(IngressoService ingresso)
        {
            _ingresso = ingresso;
        }

        [Authorize]
        [HttpGet]
        [Route("ingresso")]
        public async Task<IActionResult> getAllAsync()
        {
            var list = await _ingresso.FindAllAsync();
            return list == null ? NotFound() : Ok(list);

        }

        [Authorize]
        [HttpGet]
        [Route("ingresso/{id}")]
        public async Task<IActionResult> getByIdAsync([FromRoute] int id)
        {
            var ingresso = await _ingresso.FindByIdAsync(id);
            return ingresso == null ? NotFound() : Ok(ingresso);
        }

        [Authorize]
        [HttpPost]
        [Route("ingresso")]
        public async Task<IActionResult> PostAsync(
           [FromBody] Ingresso ingresso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                //ingresso.CalculaValorIngresso(ingresso.TipoIngresso.PercentualDesconto, ingresso.Evento.Valor);
                await _ingresso.InsertAsync(ingresso);
                return Created($"api/evento/{ingresso.Id}", ingresso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [Authorize]
        [HttpPut]
        [Route("ingresso/{id}")]
        public async Task<IActionResult> PutAsync(
         [FromBody] Ingresso ingresso,
         [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var i = await _ingresso.FindByIdAsync(id);
            if (i == null)
                return NotFound();

            try

            {
                //i.CalculaValorIngresso(ingresso.TipoIngresso.PercentualDesconto, ingresso.Evento.Valor);
                i.TipoIngressoId = ingresso.TipoIngressoId;
                i.EventoId = ingresso.EventoId;
                i.PessoaId = ingresso.PessoaId;
                await _ingresso.UpdateAsync(i);

                return Ok(i);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpDelete]
        [Route("ingresso/{id}")]
        public async Task<IActionResult> DeletAsync(
           [FromRoute] int id
            )
        {
            var ingresso = await _ingresso.FindByIdAsync(id);
            if (ingresso == null)
                return NotFound();

            try
            {

                await _ingresso.RemoveAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}

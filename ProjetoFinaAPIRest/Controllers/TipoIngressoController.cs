using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinaAPIRest.Models;
using ProjetoFinaAPIRest.Services;

namespace ProjetoFinaAPIRest.Controllers
{
    [Route("api")]
    [ApiController]
    public class TipoIngressoController : ControllerBase
    {
        private readonly TipoIngressoService _tipoIngressoService;

        public TipoIngressoController(TipoIngressoService tipoIngressoService)
        {
            _tipoIngressoService = tipoIngressoService;
        }

        [Authorize]
        [HttpGet]
        [Route("tipoingresso")]
        public async Task<IActionResult> getAllAsync()
        {
            var list = await _tipoIngressoService.FindAllAsync();
            return list == null ? NotFound() : Ok(list);

        }

        [Authorize]
        [HttpGet]
        [Route("tipoingresso/{id}")]
        public async Task<IActionResult> getByIdAsync([FromRoute] int id)
        {
            var tIngresso = await _tipoIngressoService.FindByIdAsync(id);
            return tIngresso == null ? NotFound() : Ok(tIngresso);
        }

        [Authorize]
        [HttpPost]
        [Route("tipoingresso")]
        public async Task<IActionResult> PostAsync(
           [FromBody] TipoIngresso tipoIngresso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _tipoIngressoService.InsertAsync(tipoIngresso);
                return Created($"api/tipoingresso/{tipoIngresso.Id}", tipoIngresso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [Authorize]
        [HttpPut]
        [Route("tipoingresso/{id}")]
        public async Task<IActionResult> PutAsync(
         [FromBody] TipoIngresso tipoIngresso,
         [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var tIngresso = await _tipoIngressoService.FindByIdAsync(id);
            if (tIngresso == null)
                return NotFound();

            try

            {
                tIngresso.Tipo = tipoIngresso.Tipo;
                tIngresso.PercentualDesconto = tipoIngresso.PercentualDesconto;
               
                await _tipoIngressoService.UpdateAsync(tIngresso);

                return Ok(tIngresso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpDelete]
        [Route("tipoingresso/{id}")]
        public async Task<IActionResult> DeletAsync(
           [FromRoute] int id
            )
        {
            var tIngresso = await _tipoIngressoService.FindByIdAsync(id);
            if (tIngresso == null)
                return NotFound();

            try
            {

                await _tipoIngressoService.RemoveAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

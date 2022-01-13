using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinaAPIRest.Models;
using ProjetoFinaAPIRest.Services;

namespace ProjetoFinaAPIRest.Controllers
{
    [Route("api")]
    [ApiController]
    public class PortifolioController : ControllerBase
    {
        private readonly PortifolioService _portifolioService;

        public PortifolioController(PortifolioService portifolioService)
        {
            _portifolioService = portifolioService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("portifolio")]
        public async Task<IActionResult> getAllAsync()
        {
            var list = await _portifolioService.FindAllAsync();
            return list == null ? NotFound() : Ok(list);

        }
        [Authorize]
        [HttpGet]
        [Route("portifolio/{id}")]
        public async Task<IActionResult> getByIdAsync([FromRoute] int id)
        {
            var evento = await _portifolioService.FindByIdAsync(id);
            return evento == null ? NotFound() : Ok(evento);
        }
        [Authorize]
        [HttpPost]
        [Route("portifolio")]
        public async Task<IActionResult> PostAsync(
           [FromBody] Portifolio portifolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _portifolioService.InsertAsync(portifolio);
                return Created($"api/evento/{portifolio.Id}", portifolio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [Authorize]
        [HttpPut]
        [Route("portifolio/{id}")]
        public async Task<IActionResult> PutAsync(
         [FromBody] Portifolio portifolio,
         [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var p = await _portifolioService.FindByIdAsync(id);
            if (p == null)
                return NotFound();

            try

            {
                p.Name = portifolio.Name;
                p.Descricao = portifolio.Descricao;
                p.CaminhoFotoPrincipal = portifolio.CaminhoFotoPrincipal;
               
                await _portifolioService.UpdateAsync(p);

                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpDelete]
        [Route("portifolio/{id}")]
        public async Task<IActionResult> DeletAsync(
           [FromRoute] int id
            )
        {
            var portifolio = await _portifolioService.FindByIdAsync(id);
            if (portifolio == null)
                return NotFound();

            try
            {

                await _portifolioService.RemoveAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

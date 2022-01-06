using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinaAPIRest.Models;
using ProjetoFinaAPIRest.Services;

namespace ProjetoFinaAPIRest.Controllers
{
    [Route("api")]
    [ApiController]
    public class FotoPortifolioController : ControllerBase
    {
        private readonly FotoPortifolioService _fotoPortifolioService;

        public FotoPortifolioController(FotoPortifolioService fotoPortifolioService)
        {
            _fotoPortifolioService = fotoPortifolioService;
        }

        [HttpGet]
        [Route("fotoportifolio")]
        public async Task<IActionResult> getAllAsync()
        {
            var list = await _fotoPortifolioService.FindAllAsync();
            return list == null ? NotFound() : Ok(list);

        }
        [HttpGet]
        [Route("fotoportifolio/{id}")]
        public async Task<IActionResult> getByIdAsync([FromRoute] int id)
        {
            var evento = await _fotoPortifolioService.FindByIdAsync(id);
            return evento == null ? NotFound() : Ok(evento);
        }

        [HttpPost]
        [Route("fotoportifolio")]
        public async Task<IActionResult> PostAsync(
           [FromBody] FotoPortifolio fotoPortifolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _fotoPortifolioService.InsertAsync(fotoPortifolio);
                return Created($"api/evento/{fotoPortifolio.Id}", fotoPortifolio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut]
        [Route("fotoportifolio/{id}")]
        public async Task<IActionResult> PutAsync(
         [FromBody] FotoPortifolio fotoPortifolio,
         [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var fPortifolio = await _fotoPortifolioService.FindByIdAsync(id);
            if (fPortifolio == null)
                return NotFound();

            try

            {
                fPortifolio.CaminhoFoto = fotoPortifolio.CaminhoFoto;
                fPortifolio.PortifolioId = fotoPortifolio.PortifolioId;
                await _fotoPortifolioService.UpdateAsync(fPortifolio);

                return Ok(fPortifolio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("fotoportifolio/{id}")]
        public async Task<IActionResult> DeletAsync(
           [FromRoute] int id
            )
        {
            var fPortifolio = await _fotoPortifolioService.FindByIdAsync(id);
            if (fPortifolio == null)
                return NotFound();

            try
            {

                await _fotoPortifolioService.RemoveAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

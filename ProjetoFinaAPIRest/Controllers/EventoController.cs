using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinaAPIRest.Models;
using ProjetoFinaAPIRest.Services;

namespace ProjetoFinaAPIRest.Controllers
{
    [Route("api")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly EventoService _evento;

        public EventoController(EventoService evento)
        {
            _evento = evento;
        }

        [Authorize]
        [HttpGet]
        [Route("evento")]
        public async Task<IActionResult> getAllAsync()
        {
            var list = await _evento.FindAllAsync();
            return list == null ? NotFound() : Ok(list);

        }
        [Authorize]
        [HttpGet]
        [Route("evento/{id}")]
        public async Task<IActionResult> getByIdAsync([FromRoute] int id)
        {
            var evento = await _evento.FindByIdAsync(id);
            return evento == null ? NotFound() : Ok(evento);
        }
        [Authorize]
        [HttpPost]
        [Route("evento")]
        public async Task<IActionResult> PostAsync(
           [FromBody] Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _evento.InsertAsync(evento);
                return Created($"api/evento/{evento.Id}", evento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [Authorize]
        [HttpPut]
        [Route("evento/{id}")]
        public async Task<IActionResult> PutAsync(
         [FromBody] Evento evento,
         [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var e = await _evento.FindByIdAsync(id);
            if (e == null)
                return NotFound();

            try

            {
                e.Nome = evento.Nome;
                e.Descricao = evento.Descricao;
                e.DataInicio = evento.DataInicio;
                e.DataFim = evento.DataFim;
                e.Valor = evento.Valor;
                e.LocalEventoId = evento.LocalEventoId;
                await _evento.UpdateAsync(e);

                return Ok(e);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Authorize]
        [HttpDelete]
        [Route("evento/{id}")]
        public async Task<IActionResult> DeletAsync(
           [FromRoute] int id
            )
        {
            var lEvento = await _evento.FindByIdAsync(id);
            if (lEvento == null)
                return NotFound();

            try
            {

                await _evento.RemoveAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("evento/date")]
        public async Task<IActionResult> GetByDateAsync()
        {
            var evento = await _evento.FindByDate();
            return evento == null ? NotFound() : Ok(evento);
        }

    }
}

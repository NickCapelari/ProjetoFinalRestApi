using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinaAPIRest.Models;
using ProjetoFinaAPIRest.Services;

namespace ProjetoFinaAPIRest.Controllers
{
    [Route("api")]
    [ApiController]
    public class LocalEventoController : ControllerBase
    {
        private readonly LocalEventoService _localEventoService;

        public LocalEventoController(LocalEventoService localEventoService)
        {
            _localEventoService = localEventoService;
        }

        [Authorize]
        [HttpGet]
        [Route("localevento")]
        public async Task<IActionResult> getAllAsync()
        {
            var list = await _localEventoService.FindAllAsync();
            return list == null? NotFound():Ok(list);

        }

        [Authorize]
        [HttpGet]
        [Route("localevento/{id}")]
        public async Task<IActionResult> getByIdAsync([FromRoute] int id)
        {
           var localEvento = await _localEventoService.FindByIdAsync(id);
            return localEvento == null ? NotFound() : Ok(localEvento);
        }

        [Authorize]
        [HttpPost]
        [Route("localevento")]
        public async Task<IActionResult> PostAsync(
           [FromBody] LocalEvento localEvento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _localEventoService.InsertAsync(localEvento);
                return Created($"api/localevento/{localEvento.Id}", localEvento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [Authorize]
        [HttpPut]
        [Route("localevento/{id}")]
        public async Task<IActionResult> PutAsync(
         [FromBody] LocalEvento localEvento,
         [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var lEvento = await _localEventoService.FindByIdAsync(id);
            if (lEvento == null)
                return NotFound();

            try
            
            {
                lEvento.Name = localEvento.Name;
                lEvento.Descricao = localEvento.Descricao;
                lEvento.Logradouro = localEvento.Logradouro;
                lEvento.Numero = localEvento.Numero;
                lEvento.Bairro = localEvento.Bairro;
                lEvento.Cidade = localEvento.Cidade;
                lEvento.UF = localEvento.UF;
                lEvento.CEP = localEvento.CEP;
                await _localEventoService.UpdateAsync(lEvento);

                return Ok(lEvento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpDelete]
        [Route("localevento/{id}")]
        public async Task<IActionResult> DeletAsync(
           [FromRoute] int id
            )
        {
            var lEvento = await _localEventoService.FindByIdAsync(id);
            if (lEvento == null)
                return NotFound();

            try
            {

                await _localEventoService.RemoveAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinaAPIRest.Models;
using ProjetoFinaAPIRest.Services;

namespace ProjetoFinaAPIRest.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("usuario")]
        public async Task<IActionResult> getAllAsync()
        {
            var list = await _usuarioService.FindAllAsync();
            return list == null ? NotFound() : Ok(list);

        }
        //[HttpGet]
        //[Route("usuario/{id}")]
        //public async Task<IActionResult> getByIdAsync([FromRoute] int id)
        //{
        //    var user = await _usuarioService.FindByIdAsync(id);
        //    return user == null ? NotFound() : Ok(user);
        //}
        [HttpGet]
        [Route("usuario/{login}")]
        public async Task<IActionResult> getByNameAsync([FromRoute] string login)
        {
            var user = await _usuarioService.FindByNameAsync(login);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        [Route("usuario")]
        public async Task<IActionResult> PostAsync(
           [FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _usuarioService.InsertAsync(usuario);
                return Created($"api/usuario/{usuario.Id}", usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpDelete]
        [Route("usuario/{id}")]
        public async Task<IActionResult> DeletAsync(
           [FromRoute] int id
            )
        {
            var contato = await _usuarioService.FindByIdAsync(id);
            if (contato == null)
                return NotFound();

            try
            {

                await _usuarioService.RemoveAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        public readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> ObternerLista()
        {
            var result = await _usuarioService.ObtenerUsuario();
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            var result = await _usuarioService.ObtenerUsuario(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario( [FromBody] UsuarioResponse request)
        {
            var result = await _usuarioService.CrearUsuario(request);
            return Ok(result); 

        }

        [HttpPut("id")]
        public async Task<IActionResult> Actualizar([FromBody] UsuarioResponse request, int id) 
        {
            var result = await _usuarioService.ActualizarUsuario(id, request);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _usuarioService.EliminarUsuario(id);
            return Ok(result);
        }
    }
}

using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace ProyectoMajo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorService _autorServices;

        public AutoresController(IAutorService autorServices)
        {

            _autorServices = autorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            var result = await _autorServices.GetAutores();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearAutor([FromBody] Autor request)
        {
            var result = await _autorServices.Crear(request);

            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> ActualizarAutor([FromBody] Autor request)
        {
            var result = await _autorServices.Actualizar(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarAutor(int id)
        {
            var result = await _autorServices.Eliminar(id);
            return Ok(result);
        }



    }
}
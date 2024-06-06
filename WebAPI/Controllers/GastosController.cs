using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GastosController : ControllerBase
    {
        public readonly IGastoService _gastoService;
        public GastosController(IGastoService gastoService)
        {
            _gastoService = gastoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObternerGastos()
        {
            var result = await _gastoService.ObtenerGastos();
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> ObtenerGasto(int id)
        {
            var result = await _gastoService.ObtenerGasto(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearGasto([FromBody] GastoResponse request)
        {
            var result = await _gastoService.CrearGasto(request);
            return Ok(result);

        }

        [HttpPut("id")]
        public async Task<IActionResult> Actualizar([FromBody] GastoResponse request, int id)
        {
            var result = await _gastoService.ActualizarGasto(id, request);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _gastoService.EliminarGasto(id);
            return Ok(result);
        }

    }
}

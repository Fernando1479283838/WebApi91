using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public interface IGastoService
    {
        public Task<Response<List<Gasto>>> ObtenerGastos();
        public Task<Response<Gasto>> ObtenerGasto(int id);
        public Task<Response<Gasto>> CrearGasto(GastoResponse request);
        public Task<Response<Gasto>> ActualizarGasto(int id, GastoResponse gasto);
        public Task<Response<Gasto>> EliminarGasto(int id);

    }
}

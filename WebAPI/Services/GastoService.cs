using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebAPI.Context;

namespace WebAPI.Services
{
    public class GastoService : IGastoService
    {
        private readonly ApplicationDbContext _context;

        public GastoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET de Gastos
        public async Task<Response<List<Gasto>>> ObtenerGastos()
        {
            try
            {
                List<Gasto> response = await _context.Gastos.ToListAsync();
                return new Response<List<Gasto>>(response);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        // GET id gasto
        public async Task<Response<Gasto>> ObtenerGasto(int id)
        {
            try
            {
                Gasto res = await _context.Gastos.FirstOrDefaultAsync(x => x.Id == id);
                return new Response<Gasto>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error:" + ex.Message);
            }
        }

        // POST
        public async Task<Response<Gasto>> CrearGasto(GastoResponse request)
        {
            try
            {
                Gasto gasto = new Gasto()
                {
                    Tipo = request.Tipo,
                    Cantidad = request.Cantidad,
                    Descripcion = request.Descripcion,
                    Fecha = request.Fecha,
                };

                _context.Gastos.Add(gasto);
                await _context.SaveChangesAsync();

                return new Response<Gasto>(gasto);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }

        }

        // PUT
        public async Task<Response<Gasto>> ActualizarGasto(int id, GastoResponse gasto)
        {
            try
            {
                Gasto gas = await _context.Gastos.FirstOrDefaultAsync(x => x.Id == id);

                if (gas != null)
                {
                    gas.Cantidad = gasto.Cantidad;
                    gas.Tipo = gasto.Tipo;
                    gas.Descripcion = gasto.Descripcion;
                    gas.Fecha = gasto.Fecha;
                    _context.SaveChanges();
                }

                Gasto newGasto = new Gasto()
                {
                    Tipo = gasto.Tipo,
                    Descripcion = gasto.Descripcion,
                    Fecha = gasto.Fecha,
                    Cantidad = gasto.Cantidad,
                };

                _context.Gastos.Update(gas);
                await _context.SaveChangesAsync();

                return new Response<Gasto>(newGasto);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error al actualizar" + ex.Message);
            }
        }

        // DELETE
        public async Task<Response<Gasto>> EliminarGasto(int id)
        {
            try
            {
                Gasto gasto = await _context.Gastos.FirstOrDefaultAsync(x => x.Id == id);
                if (gasto != null)
                {
                    _context.Gastos.Remove(gasto);
                    await _context.SaveChangesAsync();
                    return new Response<Gasto>("Gasto eliminado:" + gasto.Id.ToString());
                }

                return new Response<Gasto>("Gasto no encontrado:" + id);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar" + ex.Message);
            }

        }

    }
}

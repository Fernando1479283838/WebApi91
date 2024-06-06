using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebAPI.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebAPI.Services;

namespace WebAPI.Services
{
    public class AutorService : IAutorService
    {
        private readonly ApplicationDbContext _context;

        public AutorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", commandType: CommandType.StoredProcedure);
                return new Response<List<Autor>>(result.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error: " + ex.Message);
            }
        }

        public async Task<Response<Autor>> Crear(Autor a)
        {
            try
            {
                var result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spCrearAutor", new { a.Nombre, a.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<Autor>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error: " + ex.Message);
            }
        }

        public async Task<Response<Autor>> Actualizar(Autor a)
        {
            try
            {
                var result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spActualizarAutor", new { a.PkAutor, a.Nombre, a.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<Autor>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error: " + ex.Message);
            }
        }

        public async Task<Response<bool>> Eliminar(int id)
        {
            try
            {
                var result = await _context.Database.GetDbConnection().ExecuteAsync("spEliminarAutor", new { PkAutor = id }, commandType: CommandType.StoredProcedure);
                return new Response<bool>(result > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error: " + ex.Message);
            }
        }
    }
}

using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IAutorService
    {
        Task<Response<List<Autor>>> GetAutores();
        Task<Response<Autor>> Crear(Autor a);
        Task<Response<Autor>> Actualizar(Autor a);
        Task<Response<bool>> Eliminar(int id);
    }
}

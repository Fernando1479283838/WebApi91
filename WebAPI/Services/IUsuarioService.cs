using Domain.DTO;
using Domain.Entities;

namespace WebAPI.Services
{
    public interface IUsuarioService
    {
        public Task<Response<List<Usuario>>> ObtenerUsuario();
        public Task<Response<Usuario>> ObtenerUsuario(int id);
        public Task<Response<Usuario>> CrearUsuario(UsuarioResponse request);
        public Task<Response<Usuario>> ActualizarUsuario(int id, UsuarioResponse usuario);
        public Task<Response<Usuario>> EliminarUsuario(int id);



    }
}

using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using WebAPI.Context;

namespace WebAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lista de usuarios
        public async Task<Response<List<Usuario>>> ObtenerUsuario()
        {
            try
            {
                List<Usuario> response = await _context.Usuarios.Include(x => x.Roles).ToListAsync();
                return new Response<List<Usuario>>(response);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<Usuario>> ObtenerUsuario(int id)
        {
            try
            {
                Usuario res = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);
                return new Response<Usuario>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error:" + ex.Message);
            }
        }

        public async Task<Response<Usuario>> CrearUsuario(UsuarioResponse request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    User = request.User,
                    Password = request.Password,
                    FkRol = request.FkRol,
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario);

                //usuario.Nombre = request.Nombre;
                //usuario.User = request.User;
                //usuario.Password = request.Password;
                //usuario.FkRol = request.FkRol;


            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }

        }

        public async Task<Response<Usuario>> ActualizarUsuario(int id, UsuarioResponse usuario)
        {
            try
            {
                Usuario us = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);

                if (us != null)
                {
                    us.Nombre = usuario.Nombre;
                    us.User = usuario.User;
                    us.Password = usuario.Password;
                    us.FkRol = usuario.FkRol;
                    _context.SaveChanges();
                }

                Usuario newUsuario = new Usuario()
                {
                    Nombre = usuario.Nombre,
                    User = usuario.User,
                    Password = usuario.Password,
                    FkRol = usuario.FkRol,
                };

                _context.Usuarios.Update(us);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(newUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error al actualizar" + ex.Message);
            }
        }

        public async Task<Response<Usuario>> EliminarUsuario(int id)
        {
            try
            {
                Usuario us = await _context.Usuarios.FirstOrDefaultAsync(x => x.PkUsuario == id);
                if (us != null)
                {
                    _context.Usuarios.Remove(us);
                    await _context.SaveChangesAsync();
                    return new Response<Usuario>("Usuario eliminado:" + us.Nombre.ToString());
                }

                return new Response<Usuario>("Usuario no encontrado" + id);

            }
            catch (Exception ex) 
            {
                throw new Exception("Error al eliminar" + ex.Message);
            }

        }

    }
}

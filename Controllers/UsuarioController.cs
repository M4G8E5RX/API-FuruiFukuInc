using API_FuruiFukuInc.Models;
using API_FuruiFukuInc.Models.DTO;
using API_FuruiFukuInc.Resources;
using API_FuruiFukuInc.Utilities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using IdentityModel;

namespace API_FuruiFukuInc.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly APIDBContext _context;
        private ResponseDTO _response;

        public UsuarioController(APIDBContext context)
        {
            _context = context;
            _response = new ResponseDTO();
        }

        [HttpGet("GetUsers")]
        public ResponseDTO GetUsers()
        {
            try
            {
                IEnumerable<Usuario> usuarios = _context.Usuario.ToList();
                _response.Data = usuarios;
                _response.Message = "Consulta exitosa";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Ha ocurrido un error: " + ex.Message;
            }

            return _response;
        }

        [HttpGet("GetUserById/{id}")]
        public ResponseDTO GetUserById(int id)
        {
            try
            {
                var usuario = _context.Usuario.FirstOrDefault(u => u.Id == id);
                _response.Data = usuario;
                _response.Message = "Consulta exitosa";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Ha ocurrido un error: " + ex.Message;
            }

            return _response;
        }

        [HttpGet("GetUserByUsername/{username}")]
        public ResponseDTO GetUserByUserName(string username)
        {
            try
            {
                var usuario = _context.Usuario.FirstOrDefault(u => u.UserName == username);
                _response.Data = usuario;
                _response.Message = "Consulta exitosa";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Ha ocurrido un error: " + ex.Message;
            }

            return _response;
        }

        [HttpPost("CreateUser")]
        public ResponseDTO CreateUser([FromBody] Usuario usuario)
        {
            try
            {
                usuario.Password = Encrypt.HashPassword(usuario.Password);
                _context.Usuario.Add(usuario);
                _context.SaveChanges();

                _response.Data = usuario;
                _response.Message = "Usuario creado exitosamente";
            } catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Ha ocurrido un error: " + ex.Message;
            }

            return _response;
        }

        [HttpPatch("UpdateUser")]
        public async Task<ResponseDTO> UpdateUser([FromBody] Usuario usuario)
        {
            try
            {
                // Fetch the user by ID (assuming Usuario has an Id property)
                var userToUpdate = await _context.Usuario.FindAsync(usuario.Id);

                if (userToUpdate == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Usuario no encontrado";
                    return _response;
                }

                // Update specific properties based on usuario
                if (usuario.Nombre != null)
                {
                    userToUpdate.Nombre = usuario.Nombre;
                }

                if (usuario.UserName != null)
                {
                    userToUpdate.UserName = usuario.UserName;
                }
                 
                if (usuario.Puesto != null)
                {
                    userToUpdate.Puesto = usuario.Puesto;
                }

                // Handle password update if provided (assuming a separate property)
                if (usuario.Password != null)
                {
                    userToUpdate.Password = Encrypt.HashPassword(usuario.Password); // Implement HashPassword method
                }

                // Update the user in the context
                _context.Usuario.Update(userToUpdate);
                await _context.SaveChangesAsync();

                _response.Data = userToUpdate;
                _response.Message = "Usuario actualizado exitosamente";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Ha ocurrido un error: " + ex.Message;
            }

            return _response;
        }


        [HttpDelete("DeleteUser/{id}")]
        public ResponseDTO DeleteUser(int id)
        {
            try
            {
                var usuario = _context.Usuario.FirstOrDefault(u => u.Id == id);
                if (usuario != null)
                {
                    _context.Remove(usuario);
                    _context.SaveChanges();
                    _response.Message = "Usuario eliminado exitosamente";
                } else
                {
                    _response.Message = "Usuario no encontrado";
                }
                
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Ha ocurrido un error: " + ex.Message;
            }

            return _response;
        }
    }
}

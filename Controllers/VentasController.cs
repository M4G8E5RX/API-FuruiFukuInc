using API_FuruiFukuInc.Models.DTO;
using API_FuruiFukuInc.Models;
using API_FuruiFukuInc.Resources;
using API_FuruiFukuInc.Utilities;

using Microsoft.AspNetCore.Mvc;

namespace API_FuruiFukuInc.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class VentasController : Controller
    {
        private readonly APIDBContext _context;
        private ResponseDTO _response;

        public VentasController(APIDBContext context)
        {
            _context = context;
            _response = new ResponseDTO();
        }

        [HttpGet("GetSales")]
        public ResponseDTO GetSales()
        {
            try
            {
                IEnumerable<Ventas> ventas = _context.Ventas.ToList();
                _response.Data = ventas;
                _response.Message = "Consulta exitosa";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Ha ocurrido un error: " + ex.Message;
            }

            return _response;
        }

        [HttpGet("GetSaleById/{id}")]
        public ResponseDTO GetSaleById(int id)
        {
            try
            {
                var venta = _context.Ventas.FirstOrDefault(s => s.Id == id);
                _response.Data = venta;
                _response.Message = "Consulta exitosa";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Ha ocurrido un error: " + ex.Message;
            }

            return _response;
        }

        [HttpPost("SaveSale")]
        public ResponseDTO SaveSale([FromBody] Ventas venta)
        {
            try
            {
                _context.Ventas.Add(venta);
                _context.SaveChanges();

                _response.Data = venta;
                _response.Message = "Venta creada exitosamente";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Ha ocurrido un error: " + ex.Message;
            }

            return _response;
        }

        [HttpPatch("UpdateSale")]
        public async Task<ResponseDTO> UpdateSale([FromBody] Ventas venta)
        {
            try
            {
                // Fetch the user by ID (assuming Ventas has an Id property)
                var userToUpdate = await _context.Ventas.FindAsync(venta.Id);

                if (userToUpdate == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Venta no encontrada";
                    return _response;
                }

                // Update specific properties based on usuario
                if (venta.EstatusVenta != null)
                {
                    userToUpdate.EstatusVenta = venta.EstatusVenta;
                }

                if (venta.EstatusSupervision != null)
                {
                    userToUpdate.EstatusSupervision = venta.EstatusSupervision;
                }

                // Update the user in the context
                _context.Ventas.Update(userToUpdate);
                await _context.SaveChangesAsync();

                _response.Data = userToUpdate;
                _response.Message = "Venta actualizada exitosamente";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Ha ocurrido un error: " + ex.Message;
            }

            return _response;
        }


        [HttpDelete("DeleteSale/{id}")]
        public ResponseDTO DeleteSale(int id)
        {
            try
            {
                var venta = _context.Ventas.FirstOrDefault(s => s.Id == id);
                if (venta != null)
                {
                    _context.Remove(venta);
                    _context.SaveChanges();
                    _response.Message = "Venta eliminada exitosamente";
                }
                else
                {
                    _response.Message = "Ventaa no encontrada";
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bscApi.Helpers;
using bscApi.Models;
using bscApi.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace bscApi.Controllers
{
    [Route("orders")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly bscContext _context;
        public OrdersController(bscContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ObjectResult> GetOrder()
        {
            try
            {
                var order = await _context.VwGetOrders.ToListAsync();
                return new OkObjectResult(order);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost]
        public async Task<ObjectResult> AddOrder([FromBody] OrderDTO data)
        {
            try
            {
                var pendingStatus = await _context.CatEstatusPedidos.Where(x => x.EstatusPedidos == "Pendiente").Select(x => x.IdEstatusPedidos).FirstOrDefaultAsync();
                var order = new Pedido
                {
                    IdUsuario = 1,
                    IdCliente = data.IdCliente,
                    IdEstatusPedido = pendingStatus,
                    Cantidad = data.Cantidad,
                    PrecioTotal = data.Precio
                };
                await _context.Pedidos.AddAsync(order);
                await _context.SaveChangesAsync();
                return new OkObjectResult(order);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
        
    }
}

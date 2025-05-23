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
    [Route("products")]
    [Authorize]
    public class ProductsController : ControllerBase
    {

        private readonly bscContext _context;
        public ProductsController(bscContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _context.VwGetProducts.ToListAsync();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO data)
        {
            try
            {
                var prod = new Producto
                {
                    Producto1 = data.Producto,
                    Precio = data.Precio,
                    Cantidad = data.Cantidad,
                    IdCategoriaProducto = data.IdCategoria,
                };
                await _context.Productos.AddAsync(prod);
                await _context.SaveChangesAsync();
                return Ok(prod);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{idProducto}")]
        public async Task<ObjectResult> UpdateProduct([FromRoute] int idProducto, [FromBody] ProductDTO data)
        {
            try
            {
                var product = await _context.Productos.Where(x => x.IdProducto == idProducto).FirstOrDefaultAsync();
                if (product == null) return NotFound($"No se encontró el producto con ID {idProducto}");

                product.Producto1 = data.Producto;
                product.Precio = data.Precio;
                product.Cantidad = data.Cantidad;
                product.IdCategoriaProducto = data.IdCategoria;

                _context.Productos.Update(product);
                await _context.SaveChangesAsync();
                return new OkObjectResult(product);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{idProducto}")]
        public async Task<ObjectResult> DeleteProfile([FromRoute] int idProducto)
        {
            try
            {
                var deleteProd = await _context.Productos.Where(x => x.IdProducto == idProducto).FirstOrDefaultAsync();
                _context.Productos.Remove(deleteProd);
                await _context.SaveChangesAsync();
                string message = "Se ha eliminado exitosamente el perfil del documento.";
                return Ok(new {  message });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}

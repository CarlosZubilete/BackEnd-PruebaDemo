using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApi_PruebaDemo.Models;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_PruebaDemo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductosController : ControllerBase
  {
    private readonly PruebademoContext _dbContext;

    public ProductosController(PruebademoContext dbContext)
    {
      _dbContext = dbContext;
    }

    // GET: api/<ProductosController>
    [HttpGet]
    [Route("lista")]
    public async Task<IActionResult> Get()
    {
      //var lista = await _dbContext.Productos.ToListAsync();
      var lista = await _dbContext.Productos
                        .Where(p => !p.Eliminado)
                        .ToListAsync();
      return StatusCode(StatusCodes.Status200OK, lista);
    }

    // GET api/<ProductosController>/
    [HttpGet]
    [Route("producto/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
      var producto = await _dbContext.Productos
                           .FirstOrDefaultAsync(p => p.Id == id && !p.Eliminado);

      if (producto == null) return StatusCode(StatusCodes.Status404NotFound, new { mensage = "Producto not found" });

      return StatusCode(StatusCodes.Status200OK, producto);
    }

    // POST api/<ProductosController>
    [HttpPost]
    [Route("nuevo")]
    public async Task<IActionResult> NewProducto([FromBody] Producto producto)
    {
      await _dbContext.Productos.AddAsync(producto);
      await _dbContext.SaveChangesAsync();
      return StatusCode(StatusCodes.Status200OK, new { mensage = "OK" });
    }

    // PUT api/<ProductosController>/
    /*
    [HttpPut]
    [Route("editar")]
    public async Task<IActionResult> Update([FromBody] Producto producto)
    {
      _dbContext.Productos.Update(producto);
      await _dbContext.SaveChangesAsync();
      return StatusCode(StatusCodes.Status200OK, new { mensage = "OK" });
    }
    */
    // PATCH api/<ProductosController>/
    [HttpPatch("editar/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Producto producto)
    {
      var existingProducto = await _dbContext.Productos
                                  .FirstOrDefaultAsync(p => p.Id == id && !p.Eliminado);

      if (existingProducto == null) return StatusCode(StatusCodes.Status404NotFound, new { mensage = "Producto not found" });
      // Update only the fields that are provided
      existingProducto.Nombre = producto.Nombre ?? existingProducto.Nombre;
      existingProducto.Precio = producto.Precio ?? existingProducto.Precio;
      existingProducto.Categoria = producto.Categoria ?? existingProducto.Categoria;

      _dbContext.Productos.Update(existingProducto);
      await _dbContext.SaveChangesAsync();
      return StatusCode(StatusCodes.Status200OK, new { mensage = "OK" });
    }

    // DELETE api/<ProductosController>/
    [HttpDelete]
    [Route("eliminar/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      var producto = await _dbContext.Productos
                           .FirstOrDefaultAsync(p => p.Id == id && !p.Eliminado);

      if (producto == null) return StatusCode(StatusCodes.Status404NotFound, new { mensage = "Producto not found" });

      // Soft delete
      producto.Eliminado = true;
      // _dbContext.Productos.Remove(producto);
      await _dbContext.SaveChangesAsync();
      return StatusCode(StatusCodes.Status200OK, producto);
    }
  }
}

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
    [Route("ListaProductos")]
    public async Task<IActionResult> Get()
    {
      var listaProductos = await _dbContext.Productos.ToListAsync();
      return StatusCode(StatusCodes.Status200OK, listaProductos);
    }

    // GET api/<ProductosController>/5
    [HttpGet]
    [Route("ListaProductos/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
      var producto = await _dbContext.Productos.FirstOrDefaultAsync(producto => producto.Id == id);
      return StatusCode(StatusCodes.Status200OK, producto);
    }

    // POST api/<ProductosController>
    [HttpPost]
    [Route("NuevoProducto")]
    public async Task<IActionResult> NewProducto([FromBody] Producto producto)
    {
      await _dbContext.Productos.AddAsync(producto);
      await _dbContext.SaveChangesAsync();
      return StatusCode(StatusCodes.Status200OK, new { mensage = "OK" });
    }

    // PUT api/<ProductosController>/5
    [HttpPut]
    [Route("Editar")]
    public async Task<IActionResult> Update([FromBody] Producto producto)
    {
      _dbContext.Productos.Update(producto);
      await _dbContext.SaveChangesAsync();
      return StatusCode(StatusCodes.Status200OK, new { mensage = "OK" });
    }

    // DELETE api/<ProductosController>/5
    [HttpDelete]
    [Route("Eliminar/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      var producto = await _dbContext.Productos.FirstOrDefaultAsync(producto => producto.Id == id);
      _dbContext.Productos.Remove(producto);
      await _dbContext.SaveChangesAsync();
      return StatusCode(StatusCodes.Status200OK, producto);
    }
  }
}

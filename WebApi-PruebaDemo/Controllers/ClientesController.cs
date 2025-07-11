using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApi_PruebaDemo.Models; // include the file Models.
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Services; // Include the library.

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_PruebaDemo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClientesController : ControllerBase
  {
    private readonly PruebademoContext _dbContext;
    private int id;

    public ClientesController (PruebademoContext dbContext)// Declarated construcot:
    {
      _dbContext =  dbContext;
    }
    
    
    // GET: api/<ClientesController>
    [HttpGet]
    [Route("LitaClientes")]
    public async Task<IActionResult> Get()
    {
      var listaClientes = await _dbContext.Clientes.ToListAsync();
      return StatusCode(StatusCodes.Status200OK, listaClientes);
    }



    // GET api/<ClientesController>/5
    [HttpGet]
    [Route("LitaClientes/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
      var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);
      return StatusCode(StatusCodes.Status200OK, cliente);
    }


    // POST api/<ClientesController>
    [HttpPost]
    [Route("nuevoCliente")]
    public async Task<IActionResult> NewCliente([FromBody] Cliente cliente)
    {
      await _dbContext.Clientes.AddAsync(cliente);
      await _dbContext.SaveChangesAsync();
      return StatusCode(StatusCodes.Status200OK, new { mensage = "OK" });
    }

    // PUT api/<ClientesController>/5
    [HttpPut]
    [Route("editar")]
    public async Task<IActionResult> Update([FromBody] Cliente cliente)
    {
      _dbContext.Clientes.Update(cliente);
      await _dbContext.SaveChangesAsync();
      return StatusCode(StatusCodes.Status200OK, new { mensage = "OK" });
    }

    // DELETE api/<ClientesController>/5
    [HttpDelete]
    [Route("eliminar/{id:int}")]
    public async Task<IActionResult> DeleteById(int id)
    {
      var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);
      _dbContext.Clientes.Remove(cliente);
      await _dbContext.SaveChangesAsync();
      return StatusCode(StatusCodes.Status200OK, cliente);
    }
  }
}

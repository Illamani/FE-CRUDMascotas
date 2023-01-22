using BE_CRUDMascotas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_CRUDMascotas.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MascotasController : ControllerBase
  {
    private readonly AplicationDbContext _context;

    public MascotasController(AplicationDbContext context)
    {
      _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetMascota()
    {
      try
      {
        var listMascotas = await _context.Mascotas.ToListAsync();
        return Ok(listMascotas);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
        var mascota = await _context.Mascotas.FindAsync(id);
        if (mascota == null) { return NotFound(); }
        return Ok(mascota);
      }
      catch (Exception ex)
      {
        return BadRequest($"{ex.Message}");
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        var mascota = await _context.Mascotas.FindAsync(id);
        if (mascota == null)
        {
          return NotFound();
        }
        _context.Mascotas.Remove(mascota);
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Mascotas mascotas)
    {
      try
      {
        mascotas.FechaCreacion = DateTime.Now;
        _context.Add(mascotas);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Get",new {id = mascotas.Id},mascotas);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}

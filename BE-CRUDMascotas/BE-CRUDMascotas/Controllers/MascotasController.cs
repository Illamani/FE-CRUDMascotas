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
        Thread.Sleep(2000);
        var listMascotas = await _context.Mascotas.ToListAsync();
        return Ok(listMascotas);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}

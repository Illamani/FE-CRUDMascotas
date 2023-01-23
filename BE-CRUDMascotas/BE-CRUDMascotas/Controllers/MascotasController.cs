using AutoMapper;
using BE_CRUDMascotas.Models;
using BE_CRUDMascotas.Models.Dto;
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
    private readonly IMapper _mapper;

    public MascotasController(AplicationDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetMascota()
    {
      try
      {
        var listMascotas = await _context.Mascotas.ToListAsync();
        var listMascotasDto = _mapper.Map<List<MascotaDto>>(listMascotas);
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

        var mascotaDto = _mapper.Map<MascotaDto>(mascota);

        return Ok(mascotaDto);
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
    public async Task<IActionResult> Post(MascotaDto mascotaDto)
    {
      try
      {
        var mascotas = _mapper.Map<Mascotas>(mascotaDto);

        mascotas.FechaCreacion = DateTime.Now;
        _context.Add(mascotas);
        await _context.SaveChangesAsync();
        var mascotaItemDto = _mapper.Map<MascotaDto>(mascotas);
        return CreatedAtAction("Get", new { id = mascotaItemDto.Id }, mascotaItemDto);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, MascotaDto mascotaDto)
    {
      try
      {
        var mascotas = _mapper.Map<Mascotas>(mascotaDto);
        if(id != mascotas.Id)
        {
          return BadRequest();
        }
        var mascotaItems = await _context.Mascotas.FindAsync(id);
        if(mascotaItems== null)
        {
          return NotFound();
        }
        mascotaItems.Nombre = mascotas.Nombre;
        mascotaItems.Raza = mascotas.Raza;
        mascotaItems.Edad = mascotas.Edad;
        mascotaItems.Peso= mascotas.Peso;
        mascotaItems.Color = mascotas.Color;
        await _context.SaveChangesAsync();
        return NoContent();
      }
      catch(Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}

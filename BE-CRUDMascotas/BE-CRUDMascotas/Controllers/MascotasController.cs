using AutoMapper;
using BE_CRUDMascotas.Models;
using BE_CRUDMascotas.Models.Dto;
using BE_CRUDMascotas.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_CRUDMascotas.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MascotasController : ControllerBase
  {
    private readonly IMascotaRepository _mascotaRepository;
    private readonly IMapper _mapper;

    public MascotasController(IMapper mapper,IMascotaRepository mascotaRepository)
    {
      _mapper = mapper;
      _mascotaRepository = mascotaRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetMascota()
    {
      try
      {
        var listMascotas = await _mascotaRepository.GetListMascotas();
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
        var mascota = await _mascotaRepository.GetMascotas(id);
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
        var mascota = await _mascotaRepository.GetMascotas(id);
        if (mascota == null)
        {
          return NotFound();
        }
        await _mascotaRepository.DeleteMascota(mascota);
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

        var mascota = await _mascotaRepository.AddMascota(mascotas);

        var mascotaItemDto = _mapper.Map<MascotaDto>(mascota);
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
        var mascotaItems = await _mascotaRepository.GetMascotas(id);
        if(mascotaItems== null)
        {
          return NotFound();
        }
        await _mascotaRepository.UpdateMascota(mascotaItems);
        return NoContent();
      }
      catch(Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}

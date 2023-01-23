using BE_CRUDMascotas.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace BE_CRUDMascotas.Models.Repository
{
  public class MascotaRepository : IMascotaRepository
  {
    private readonly AplicationDbContext _context;
    public MascotaRepository(AplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Mascotas> AddMascota(Mascotas mascotas)
    {
      _context.Add(mascotas);
      await _context.SaveChangesAsync();
      return mascotas;
    }

    public async Task DeleteMascota(Mascotas mascotas)
    {
      _context.Mascotas.Remove(mascotas);
      await _context.SaveChangesAsync();
    }

    public async Task<List<Mascotas>> GetListMascotas()
    {
        return await _context.Mascotas.ToListAsync();
    }

    public async Task<Mascotas> GetMascotas(int id)
    {
      return await _context.Mascotas.FindAsync(id);
    }

    public async Task UpdateMascota(Mascotas mascotas)
    {
      var mascotaItems = await _context.Mascotas.FindAsync(x => x.Id == mascota.Id);

      if(mascotaItems != null)
      {
        mascotaItems.Nombre = mascotas.Nombre;
        mascotaItems.Raza = mascotas.Raza;
        mascotaItems.Edad = mascotas.Edad;
        mascotaItems.Peso = mascotas.Peso;
        mascotaItems.Color = mascotas.Color;
        await _context.SaveChangesAsync();
      }
    }
  }
}

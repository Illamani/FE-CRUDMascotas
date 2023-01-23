namespace BE_CRUDMascotas.Models.Repository
{
  public interface IMascotaRepository
  {
    Task<List<Mascotas>> GetListMascotas();
    Task<Mascotas> GetMascotas(int id);
    Task DeleteMascota(Mascotas mascotas);
    Task<Mascotas> AddMascota(Mascotas mascotas);
    Task UpdateMascota(Mascotas mascota);
  }
}

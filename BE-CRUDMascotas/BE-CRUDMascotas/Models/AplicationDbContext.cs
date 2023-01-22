using Microsoft.EntityFrameworkCore;
namespace BE_CRUDMascotas.Models
{
  public class AplicationDbContext : DbContext
  {
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Mascotas> Mascotas { get; set; }
  }
}

namespace BE_CRUDMascotas.Models.Dto
{
  public class MascotaDto
  {
    public int Id { get; set; }
    #nullable disable
    public string Nombre { get; set; }
    public string Raza { get; set; }
    public string Color { get; set; }
    public int Edad { get; set; }
    public float Peso { get; set; }
  }
}

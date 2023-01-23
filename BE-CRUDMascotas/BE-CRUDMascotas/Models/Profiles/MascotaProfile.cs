using AutoMapper;
using BE_CRUDMascotas.Models.Dto;

namespace BE_CRUDMascotas.Models.Profiles
{
  public class MascotaProfile : Profile
  {
    public MascotaProfile() {
      CreateMap<Mascotas,MascotaDto>();
      CreateMap<MascotaDto,Mascotas>();
    }
  }
}

using AutoMapper;
using Data;

namespace ServicesLayer
{
    public class MappingProfile: Profile
    {
       public MappingProfile()
        {
            CreateMap<DTOs.BindingModel.NewSeccion, Seccione>();
            CreateMap<DTOs.BindingModel.NewStudent, Estudiante>();
            CreateMap< DTOS.BindingModel.NewMaestro, Maestro>();
        }
    }
}
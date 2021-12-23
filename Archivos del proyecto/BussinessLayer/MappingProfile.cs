using AutoMapper;
using Data;
using System.Collections.Generic;

namespace ServicesLayer
{
    public class MappingProfile: Profile
    {
       public MappingProfile()
        {
            CreateMap<DTOs.BindingModel.NewSeccion, Seccione>();
            CreateMap<Seccione, DTOS.ViewModel.SectionsViewModel>();

            CreateMap<DTOs.BindingModel.NewStudent, Estudiante>();
            CreateMap<Estudiante, DTOS.ViewModel.StudentsViewModel>();
            
            CreateMap< DTOS.BindingModel.NewMaestro, Maestro>();
            CreateMap< DTOS.BindingModel.MateriasMaestrosBinding, MateriasMaestro>();
            CreateMap<Maestro, DTOS.ViewModel.MaestrosViewModel>();
            
            CreateMap<DTOS.BindingModel.NewSubject, Materia>();
            CreateMap<Materia, DTOS.ViewModel.MateriasViewModel>();
            
            CreateMap<DTOS.BindingModel.NewAdminNotices, AvisosAdministración>();
            CreateMap<AvisosAdministración, DTOS.ViewModel.AdminNoticesViewModel>();

            CreateMap<ReportesAestudiante, DTOS.ViewModel.ReportesEstViewModel>()
                            .ForMember(r => r.Nombre, o => o.MapFrom(s => s.CedulaMaestroNavigation.Nombre));
        }
    }
}
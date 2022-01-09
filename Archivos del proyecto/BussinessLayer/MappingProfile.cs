using AutoMapper;
using Data;
using System.Collections.Generic;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.DTOS.ViewModel;
using ServicesLayer.DTOs.BindingModel;

namespace ServicesLayer
{
    public class MappingProfile: Profile
    {
       public MappingProfile()
        {
            CreateMap<NewSeccion, Seccione>();
            CreateMap<Seccione, SectionsViewModel>();

            CreateMap<NewStudent, Estudiante>();
            CreateMap<Estudiante, StudentsViewModel>();
            
            CreateMap< NewMaestro, Maestro>();
            CreateMap< MateriasMaestrosBinding, MateriasMaestro>();
            CreateMap<Maestro, MaestrosViewModel>();
            
            CreateMap<NewSubject, Materia>();
            CreateMap<Materia, MateriasViewModel>();
            
            CreateMap<NewAdminNotices, AvisosAdministración>();
            CreateMap<AvisosAdministración, AdminNoticesViewModel>();

            CreateMap<ReportesAEstBinding, ReportesAestudiante>();
            CreateMap<ReportesAestudiante, ReportesEstViewModel>()
                            .ForMember(r => r.Nombre, o => o.MapFrom(s => s.CedulaMaestroNavigation.Nombre));

            CreateMap<Excusa, ExcusesViewModel>()
                .ForMember(r => r.Nombre, o => o.MapFrom(s => s.MatriculaNavigation.Nombre))
                .ForMember(r => r.Apellido, o => o.MapFrom(s => s.MatriculaNavigation.Apellido));

            CreateMap<NoticiasAEstBinding, AvisosMaestro>();
            CreateMap<AvisosMaestro, NoticiasAEstViewModel>();
        }
    }
}
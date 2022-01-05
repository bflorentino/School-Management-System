using System;
using System.Linq;
using System.Collections.Generic;
using Data;
using AutoMapper;
using System.Threading.Tasks;
using ServicesLayer.DTOs.BindingModel;
using ServicesLayer.DTOS.ViewModel;
using ServicesLayer.Services;
using Microsoft.EntityFrameworkCore;

namespace ServicesLayer.Services.Teachers
{
    public class TeachersJobService:ITeachersJobService
    {
        private readonly IMapper _mapper;
        private readonly School_Manage_SystemContext _context;

        public TeachersJobService(IMapper mapper, School_Manage_SystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServerResponse<List<Teachers_Sections_ViewModel>>>GetJobSections(string cedula)
        {
            ServerResponse<List<Teachers_Sections_ViewModel>> serverResponse = new ServerResponse<List<Teachers_Sections_ViewModel>>();

            var sections = await (from ma in _context.MaestrosAulas
                            join mm in _context.MateriasMaestros
                            on ma.IdAsignacion equals mm.IdAsignacion
                            join m in _context.Materias on mm.CodigoMateria equals m.CodigoMateria
                            join s in _context.Secciones on ma.CodigoSeccion equals s.CodigoSeccion
                            join ats in _context.AreasTecnicas on s.IdArea equals ats.IdArea
                            where mm.Cedula == cedula
                            select new Teachers_Sections_ViewModel
                            {
                                CodigoSeccion = s.CodigoSeccion,
                                NombreMateria = m.Nombre,
                                Nivel = s.Nivel,
                                Seccion = s.Seccion,
                                NombreSeccion = ats.Nombre
                            } ).ToListAsync();

            serverResponse.Data = sections;

            return serverResponse;

            //var sections = await _context.MaestrosAulas.Include(ma => ma.IdAsignacionNavigation)
            //                                                      .Include(ma => ma.IdAsignacionNavigation.CodigoMateria)
            //                                                      .Include(ma => ma.CodigoSeccionNavigation)
            //                                                      .Include(ma => ma.CodigoSeccionNavigation.IdAreaNavigation)
            //                                                      .Where(ma => ma.IdAsignacionNavigation.Cedula == cedula).ToListAsync();

        }
    }
}

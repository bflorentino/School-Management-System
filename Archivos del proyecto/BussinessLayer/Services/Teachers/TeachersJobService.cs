using System;
using System.Linq;
using System.Collections.Generic;
using Data;
using AutoMapper;
using System.Threading.Tasks;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.DTOS.ViewModel;
using ServicesLayer.Services;
using Microsoft.EntityFrameworkCore;

namespace ServicesLayer.Services.Teachers
{
    public class TeachersJobService : ITeachersJobService
    {
        private readonly IMapper _mapper;
        private readonly School_Manage_SystemContext _context;

        public TeachersJobService(IMapper mapper, School_Manage_SystemContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServerResponse<List<Teachers_Sections_ViewModel>>> GetJobSections(string cedula)
        {
            var serverResponse = new ServerResponse<List<Teachers_Sections_ViewModel>>();

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
                                  }).ToListAsync();

            serverResponse.Data = sections;

            return serverResponse;
        }

        public async Task<ServerResponse<List<AdminNoticesViewModel>>> GetNewNotices()
        {
           var serverResponse = new ServerResponse<List<AdminNoticesViewModel>>();

            try
            {
            var notices = await _context.AvisosAdministracións.Where(c =>(c.DirigidoA == "Maestros" ||
                                                                                                        c.DirigidoA == "Toda la escuela" ||
                                                                                                        c.DirigidoA == "Toda la comunidad Educativa")
                                                                                                        && (c.VigenciaHasta >= DateTime.Now)).ToListAsync();

            serverResponse.Data = notices.Select(c => _mapper.Map<AdminNoticesViewModel>(c)).ToList();
            }
            catch (Exception)
            {
                serverResponse.Success = false;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<List<ExcusesViewModel>>> GetExcuses(string section)
        {
            var  serverResponse = new ServerResponse<List<ExcusesViewModel>>();

            try
            {
                var excuses = await _context.Excusas.Where(c => c.MatriculaNavigation.CodigoSeccion == section)
                                                                      .Include(c => c.MatriculaNavigation).ToListAsync();

                serverResponse.Data = excuses.Select(c => _mapper.Map<ExcusesViewModel>(c)).ToList();

            }
            catch (Exception ex)
            {
                serverResponse.Success = false;
                serverResponse.Message = ex.Message;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<string>> AddReportToStudent(ReportesAEstBinding report)
        {
            ServerResponse<string>serverResponse = new ServerResponse<string>();
            try
            {
                await _context.AddAsync(_mapper.Map<ReportesAestudiante>(report));
                serverResponse.Message = "El reporte fue añadido exitosamente";
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                serverResponse.Success = false;
                serverResponse.Message=ex.Message;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<string>> AddNewNotice(NoticiasAEstBinding notice)
        {
            var serverResponse = new ServerResponse<string>();
            var aviso = _mapper.Map<AvisosMaestro>(notice);
            await _context.AddAsync(aviso);

             notice.CodigoSecciones.ForEach(async (c) =>
             {
                var avisoCurso = new AvisosCurso();
                avisoCurso.IdAviso = notice.IdAviso;
                avisoCurso.CodigoSeccion = c;
                await _context.AddAsync(avisoCurso);
            });

            await _context.SaveChangesAsync();
            serverResponse.Message = "Aviso agregado con éxito";
            return serverResponse;
        }

        public async Task<ServerResponse<List<NoticiasAEstViewModel>>> GetOwnNotices(string cedula)
        {
            var serverResponse = new ServerResponse<List<NoticiasAEstViewModel>>();
            serverResponse.Data = new List<NoticiasAEstViewModel>();
            var avisos = await  _context.AvisosMaestros.Where(c => c.CedulaMaestro == cedula).ToListAsync();
            var codigosSecciones = new List<string>();

            avisos.ForEach((c) =>
            {
                codigosSecciones.Clear();
                var avisosCursos = _context.AvisosCursos.Where(d => d.IdAviso == c.IdAviso).ToList();
                var noticeMapped = _mapper.Map<NoticiasAEstViewModel>(c);
                avisosCursos.ForEach((e) => codigosSecciones.Add(e.CodigoSeccion));
                noticeMapped.CodigoSecciones = codigosSecciones;
                serverResponse.Data.Add(noticeMapped);
           });

            return serverResponse;
        }
    }
}
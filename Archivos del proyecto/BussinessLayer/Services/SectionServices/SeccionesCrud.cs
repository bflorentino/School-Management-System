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

namespace ServicesLayer.Bussiness
{
    public class SeccionesCrud : ISeccionesCrud
    {
        School_Manage_SystemContext dbContext = DBaseContext.GetContexto().Ctxto;
        private readonly IMapper map;

        public SeccionesCrud(IMapper mapper)
        {
            map = mapper;
        }

        public async Task<ServerResponse<string>> CrearSeccion(NewSeccion seccion)
        {
            ServerResponse<string> serverResponse = new ServerResponse<string>();
            Seccione section = map.Map<Seccione>(seccion);

            try
            {
                await dbContext.AddAsync(section);
                await dbContext.SaveChangesAsync();
                serverResponse.Data = "";
                serverResponse.Message = "Seccion registrado exitosamente";
            }
            catch (Exception ex)
            {
                serverResponse.Message = ex.Message;
                serverResponse.Success = false;
            }
            return serverResponse;
        }

        public async Task<ServerResponse<List<SectionsViewModel>>> GetAllSections()
        {
            ServerResponse<List<SectionsViewModel>> serverResponse = new ServerResponse<List<SectionsViewModel>>();
            try
            {
               var sections = await (from secciones in dbContext.Secciones select secciones).ToListAsync();
               serverResponse.Data = sections.Select(s => map.Map<SectionsViewModel>(s)).ToList();
            }
            catch (Exception)
            {
                serverResponse.Message = "Hubo un error al obtener los datos";
                serverResponse.Success = false;
            }
            return serverResponse;
        }
    }
}
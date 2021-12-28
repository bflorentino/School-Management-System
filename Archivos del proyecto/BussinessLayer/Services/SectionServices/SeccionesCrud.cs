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
        School_Manage_SystemContext dbContext;
        private readonly IMapper map;

        public SeccionesCrud(IMapper mapper, School_Manage_SystemContext dbCont)
        {
            map = mapper;
            dbContext = dbCont;
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
            }
            catch (Exception ex)
            {
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
                serverResponse.Success = false;
            }
            return serverResponse;
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using Data;
using AutoMapper;
using System.Threading.Tasks;
using ServicesLayer.DTOs.BindingModel;
using ServicesLayer.Services;

namespace ServicesLayer.Bussiness
{
    public class SeccionesCrud : ISeccionesCrud
    {
       School_Manage_SystemContext  dbContext = DBaseContext.GetContexto().Ctxto;
       private readonly IMapper map;

        public SeccionesCrud(IMapper mapper)
        {
            map = mapper;
        }

        public async Task<ServerResponse<string>> CrearSeccion(NewSeccion seccion)
        {
            ServerResponse<string> serverResponse = new ServerResponse<string>();
            Seccione section = map.Map<Seccione>(seccion);
            await dbContext.AddAsync(section);
            await dbContext.SaveChangesAsync();
            serverResponse.Data = "";
            serverResponse.Message = "Seccion registrado exitosamente";

            return serverResponse;
           }
        }
    }
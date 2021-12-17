using System;
using System.Linq;
using System.Collections.Generic;
using Data;
using AutoMapper;
using System.Threading.Tasks;

namespace ServicesLayer.Bussiness
{
    public class SeccionesCrud
    {
       School_Manage_SystemContext  dbContext = DBaseContext.GetContexto().Ctxto;
       private readonly IMapper map;

        public SeccionesCrud(IMapper mapper)
        {
            map = mapper;
        }

        public async Task<bool> CrearSeccion(DTOs.BindingModel.NewSeccion seccion)
        {          
                Seccione section = map.Map<Seccione>(seccion);
                 await dbContext.AddAsync(section);
                await dbContext.SaveChangesAsync();
                return true;    
            }
        }
    }
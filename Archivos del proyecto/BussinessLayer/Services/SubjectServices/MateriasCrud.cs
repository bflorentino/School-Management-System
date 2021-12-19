using System;
using Data;
using System.Threading.Tasks;
using ServicesLayer.Bussiness;
using ServicesLayer.DTOS.BindingModel;
using AutoMapper;

namespace ServicesLayer.Services.SubjectServices
{
    public class MateriasCrud:IMateriasCrud
    {

        private readonly School_Manage_SystemContext dbContext = DBaseContext.GetContexto().Ctxto;
        private readonly IMapper _mapper;

        public MateriasCrud(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<bool>AddSubject(NewSubject materia)
        {
            Materia mtria = _mapper.Map<Materia>(materia);
            await dbContext.AddAsync(mtria);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
using System;
using Data;
using System.Threading.Tasks;
using ServicesLayer.Bussiness;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer;
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

        public async Task<ServerResponse<string>>AddSubject(NewSubject materia)
        {
            ServerResponse<string> serverResponse = new ServerResponse<string>();

            Materia mtria = _mapper.Map<Materia>(materia);

            await dbContext.AddAsync(mtria);
            await dbContext.SaveChangesAsync();
            serverResponse.Data = "";
            serverResponse.Message = "Materia registrada exitosamente";

            return serverResponse;
        }
    }
}
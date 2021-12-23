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
        private readonly School_Manage_SystemContext dbContext;
        private readonly IMapper _mapper;

        public MateriasCrud(IMapper mapper, School_Manage_SystemContext dbCont)
        {
            _mapper = mapper;
            dbContext = dbCont;
        }

        public async Task<ServerResponse<string>>AddSubject(NewSubject materia)
        {
            ServerResponse<string> serverResponse = new ServerResponse<string>();
            Materia mtria = _mapper.Map<Materia>(materia);

            try
            {
                await dbContext.AddAsync(mtria);
                await dbContext.SaveChangesAsync();
                serverResponse.Data = "";
                serverResponse.Message = "Materia registrada exitosamente";
            }
            catch (Exception ex)
            {
                serverResponse.Message = ex.Message;
                serverResponse.Success = false;
            }
            return serverResponse;
        }
    }
}
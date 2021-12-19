using System;
using Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.Bussiness;
using ServicesLayer;

namespace ServicesLayer.Services.NoticesServices
{
    public class AdminNoticesCrud: IAdminNoticesCrud
    {
        private readonly School_Manage_SystemContext dbContext = DBaseContext.GetContexto().Ctxto;
        private readonly IMapper _mapper;

        public AdminNoticesCrud(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServerResponse<string>>AddNewNotice(NewAdminNotices notice)
        {
            ServerResponse<string>serverResponse = new ServerResponse<string>();
            AvisosAdministración aviso = _mapper.Map<AvisosAdministración>(notice);
            try
            {
                await dbContext.AddAsync(aviso);
                await dbContext.SaveChangesAsync();
                serverResponse.Data = "";
                serverResponse.Message = "Aviso registrado exitosamente";
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
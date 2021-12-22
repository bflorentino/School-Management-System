using System;
using Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.Bussiness;
using ServicesLayer;
using ServicesLayer.DTOS.ViewModel;
using Microsoft.EntityFrameworkCore;

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
                serverResponse.Message = "Hubo un error al intentar ingresar el nuevo registro";
                serverResponse.Success = false;
            }

            return serverResponse;
        }

        public async Task<ServerResponse<List<AdminNoticesViewModel>>>GetAllNotices()
        {
            ServerResponse<List<AdminNoticesViewModel>> serverResponse = new ServerResponse<List<AdminNoticesViewModel>>();
      
            try
            {
                var notices = await(from notice in dbContext.AvisosAdministracións
                                   select notice).ToListAsync();

                foreach (var notice in notices)
                {
                    AdminNoticesViewModel ntc = _mapper.Map<AdminNoticesViewModel>(notice);
                    serverResponse.Data.Add(ntc);
                }
            }
            catch (Exception ex)
            {
                serverResponse.Message = "Hubo un error al intentar ingresar el nuevo registro";
                serverResponse.Success = false;
            }

            return serverResponse;
        }
    }
}
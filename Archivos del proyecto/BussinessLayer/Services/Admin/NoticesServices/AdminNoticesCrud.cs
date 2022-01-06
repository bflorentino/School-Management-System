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
        private readonly School_Manage_SystemContext dbContext;
        private readonly IMapper _mapper;

        public AdminNoticesCrud(IMapper mapper, School_Manage_SystemContext dbCont)
        {
            _mapper = mapper;
            dbContext = dbCont;
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
            }
            catch (Exception)
            {
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

                serverResponse.Data = notices.Select(s => _mapper.Map<AdminNoticesViewModel>(s)).ToList();
            }
            catch (Exception)
            {
                serverResponse.Success = false;
            }
            return serverResponse;
        }
    }
}
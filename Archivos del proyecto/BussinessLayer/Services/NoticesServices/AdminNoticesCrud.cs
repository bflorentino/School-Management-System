using System;
using Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLayer.DTOS.BindingModel;
using ServicesLayer.Bussiness;

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

        public async Task<bool>AddNewNotice(NewAdminNotices notice)
        {
            AvisosAdministración aviso = _mapper.Map<AvisosAdministración>(notice);
            await dbContext.AddAsync(aviso);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenantApplicationCRUD.API.Profiles
{
    public class TenantPersonnelProfile : Profile
    {
        public TenantPersonnelProfile()
        {
            CreateMap<Entities.TenantPersonnel, Models.TenantPersonnelDto>();
        }
    }
}

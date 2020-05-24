using AutoMapper;
using TenantApplicationCRUD.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenantApplicationCRUD.API.Profiles
{
    public class GendersProfile : Profile
    {
        public GendersProfile()
        {
            CreateMap<Entities.Gender, Models.GenderDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name} {src.Name}"));

            CreateMap<Models.GenderForCreationDto, Entities.Gender>();
        }
    }
}

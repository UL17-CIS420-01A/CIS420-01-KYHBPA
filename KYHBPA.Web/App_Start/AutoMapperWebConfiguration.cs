using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace KYHBPA.Web
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<User, ApplicationUser>()
                //    .ForMember(model => model.Member,
                //        opt => opt.MapFrom(vm => vm.Member))
                //    .ForMember(model => model.Claims,
                //        opt => opt.MapFrom(vm => vm.AspNetUserClaims))
                //    .ForMember(model => model.Roles,
                //        opt => opt.MapFrom(vm => vm.AspNetRoles))
                //    .ForMember(model => model.Logins,
                //        opt => opt.MapFrom(vm => vm.AspNetUserLogins))
                //    .ReverseMap();
                /* etc */
            });
        }
    }
}


using AutoMapper;
using COVID19Tracker.Core.Entities;

namespace COVID19Tracker.Auth
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<Role, AppRole>()
                .ReverseMap();
        }
    }
}

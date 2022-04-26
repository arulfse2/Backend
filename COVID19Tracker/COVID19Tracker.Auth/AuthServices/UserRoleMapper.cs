using AutoMapper;
using COVID19Tracker.Core.Entities;

namespace COVID19Tracker.Auth
{
    public class UserRoleMapper : Profile
    {
        public UserRoleMapper()
        {
            CreateMap<UserRole, AppUserRole>()
                .ReverseMap();
        }
    }
}

using AutoMapper;
using COVID19Tracker.Core.Entities;

namespace COVID19Tracker.Auth
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, AppUser>()
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.Id.ToString()))
                .ReverseMap();
        }
    }
}

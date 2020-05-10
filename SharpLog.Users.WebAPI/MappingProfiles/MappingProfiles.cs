using AutoMapper;
using SharpLog.Users.Core.Models;
using SharpLog.Users.WebAPI.Models;

namespace SharpLog.Users.WebAPI.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserProfile, UserProfileViewModel>().ReverseMap();
        }
    }
}
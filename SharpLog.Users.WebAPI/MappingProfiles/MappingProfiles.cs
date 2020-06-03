using AutoMapper;
using SharpLog.Users.Core.Models;
using SharpLog.Users.WebAPI.Models;

namespace SharpLog.Users.WebAPI.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserProfile, CreateUserProfileViewModel>().ReverseMap();
            CreateMap<UserProfile, UserProfileViewModel>();
            CreateMap<string, GetUsernameByUsernameViewModel>()
                .ForMember(viewModel => viewModel.Username,
                    options => options.MapFrom(stringValue => stringValue));
        }
    }
}
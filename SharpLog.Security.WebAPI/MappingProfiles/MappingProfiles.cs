using AutoMapper;
using SharpLog.Security.Core.Models;
using SharpLog.Security.WebAPI.Models;

namespace SharpLog.Security.WebAPI.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserIdentity, UserIdentityViewModel>();
        }
    }
}
using AutoMapper;
using SharpLog.IGDB.Core.Models;
using SharpLog.IGDB.WebAPI.Models;

namespace SharpLog.IGDB.WebAPI.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IGDBGame, SearchedGameViewModel>();
        }
    }
}
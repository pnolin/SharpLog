using AutoMapper;
using SharpLog.Backlog.Core.Models;
using SharpLog.Backlog.WebAPI.Models;

namespace SharpLog.Backlog.WebAPI.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Core.Models.Backlog, BacklogViewModel>();
            CreateMap<Game, GameViewModel>();
        }
    }
}
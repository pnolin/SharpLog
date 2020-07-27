using AutoMapper;
using IGDB.Models;
using SharpLog.IGDB.Core.Models;
using SharpLog.IGDB.WebAPI.Models;
using System.Linq;

namespace SharpLog.IGDB.WebAPI.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IGDBGame, SearchedGameViewModel>()
                .ForMember(viewModel => viewModel.Platforms,
                    options => options.MapFrom(igdbGame => igdbGame.Platforms.Select(platform => platform.Abbreviation)))
                .ForMember(viewModel => viewModel.ReleaseYear,
                    options => options.MapFrom(game => game.FirstReleaseDate.HasValue ? game.FirstReleaseDate.Value.Year : (int?)null));

            CreateMap<Game, IGDBGame>()
                .ForMember(igdbGame => igdbGame.Id,
                    options => options.MapFrom(game => game.Id.HasValue ? game.Id.Value.ToString() : ""))
                .ForMember(igdbGame => igdbGame.Platforms,
                    options => options.MapFrom(game => game.Platforms.Ids.Select(id => new IGDBPlatform() { Id = id.ToString() })));

            CreateMap<Platform, IGDBPlatform>()
                .ForMember(igdbGame => igdbGame.Id,
                    options => options.MapFrom(platform => platform.Id.HasValue ? platform.Id.Value.ToString() : ""));
        }
    }
}
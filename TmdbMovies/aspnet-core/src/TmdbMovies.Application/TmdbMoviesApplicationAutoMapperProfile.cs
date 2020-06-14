using AutoMapper;
using TmdbMovies.Movies;

namespace TmdbMovies
{
    public class TmdbMoviesApplicationAutoMapperProfile : Profile
    {
        public TmdbMoviesApplicationAutoMapperProfile()
        {

            CreateMap<MovieCreateDto, Movie>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieUpdateDto, Movie>();
            CreateMap<MovieResult, Movie>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}

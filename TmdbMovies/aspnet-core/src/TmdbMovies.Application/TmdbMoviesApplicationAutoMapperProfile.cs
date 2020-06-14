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
        }
    }
}

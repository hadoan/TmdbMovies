using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TmdbMovies.Movies
{
    public interface IMovieAppService : IApplicationService
    {
        Task<PagedResultDto<MovieDto>> GetListAsync(GetMoviesInput input);

        Task<MovieDto> GetAsync(long id);

        Task DeleteAsync(long id);

        Task<MovieDto> CreateAsync(MovieCreateDto input);

        Task<MovieDto> UpdateAsync(long id, MovieUpdateDto input);
    }
}
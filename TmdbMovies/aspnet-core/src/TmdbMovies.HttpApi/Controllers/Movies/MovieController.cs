using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TmdbMovies.Movies;
using Microsoft.AspNetCore.Authorization;

namespace TmdbMovies.Controllers.Movies
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Movie")]
    [Route("api/app/movie")]
    public class MovieController : AbpController, IMovieAppService
    {
        private readonly IMovieAppService _movieAppService;
        private readonly ITheMovieDbApiIntegrationService _theMovieDbApiIntegrationService;

        public MovieController(IMovieAppService movieAppService, ITheMovieDbApiIntegrationService theMovieDbApiIntegrationService)
        {
            _movieAppService = movieAppService;
            _theMovieDbApiIntegrationService = theMovieDbApiIntegrationService;
        }

        [HttpGet]
        [Route("gettrailer/{movieId}")]
        public Task<string> GetYoutubeTrailerAsync(long movieId)
        {
            return _theMovieDbApiIntegrationService.GetYoutubeTrailerId(movieId);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<MovieDto>> GetListAsync(GetMoviesInput input)
        {
            return _movieAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<MovieDto> GetAsync(long id)
        {
            return _movieAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<MovieDto> CreateAsync(MovieCreateDto input)
        {
            return _movieAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<MovieDto> UpdateAsync(long id, MovieUpdateDto input)
        {
            return _movieAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(long id)
        {
            return _movieAppService.DeleteAsync(id);
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using TmdbMovies.Permissions;
using TmdbMovies.Movies;

namespace TmdbMovies.Movies
{
    [RemoteService(IsEnabled = false)]
    //[Authorize(TmdbMoviesPermissions.Movies.Default)]
    public class MovieAppService : ApplicationService, IMovieAppService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieAppService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

        }

        public virtual async Task<PagedResultDto<MovieDto>> GetListAsync(GetMoviesInput input)
        {
            var totalCount = await _movieRepository.GetCountAsync(input.FilterText, input.PopularityMin, input.PopularityMax, input.VoteCountMin, input.VoteCountMax, input.Video, input.PosterPath, input.MovieIdMin, input.MovieIdMax, input.Adult, input.BackdropPath, input.OriginalLanguage, input.OriginalTitle, input.Title, input.VoteAverageMin, input.VoteAverageMax, input.Overview, input.ReleaseDateMin, input.ReleaseDateMax);
            var items = await _movieRepository.GetListAsync(input.FilterText, input.PopularityMin, input.PopularityMax, input.VoteCountMin, input.VoteCountMax, input.Video, input.PosterPath, input.MovieIdMin, input.MovieIdMax, input.Adult, input.BackdropPath, input.OriginalLanguage, input.OriginalTitle, input.Title, input.VoteAverageMin, input.VoteAverageMax, input.Overview, input.ReleaseDateMin, input.ReleaseDateMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<MovieDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Movie>, List<MovieDto>>(items)
            };
        }

        public virtual async Task<MovieDto> GetAsync(long id)
        {
            return ObjectMapper.Map<Movie, MovieDto>(await _movieRepository.GetAsync(id));
        }

        [Authorize(TmdbMoviesPermissions.Movies.Delete)]
        public virtual async Task DeleteAsync(long id)
        {
            await _movieRepository.DeleteAsync(id);
        }

        [Authorize(TmdbMoviesPermissions.Movies.Create)]
        public virtual async Task<MovieDto> CreateAsync(MovieCreateDto input)
        {
            var newMovie = ObjectMapper.Map<MovieCreateDto, Movie>(input);

            var movie = await _movieRepository.InsertAsync(newMovie);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<Movie, MovieDto>(movie);
        }

        [Authorize(TmdbMoviesPermissions.Movies.Edit)]
        public virtual async Task<MovieDto> UpdateAsync(long id, MovieUpdateDto input)
        {
            var movie = await _movieRepository.GetAsync(id);
            ObjectMapper.Map(input, movie);
            var updatedMovie = await _movieRepository.UpdateAsync(movie);
            return ObjectMapper.Map<Movie, MovieDto>(updatedMovie);
        }
    }
}
using AutoMapper;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace TmdbMovies.Movies
{
    public class TheMovieDbApiIntegrationService : ITheMovieDbApiIntegrationService
    {
        private readonly AsyncRetryPolicy<HttpResponseMessage> _httpRequestPolicy;
        private readonly HttpClient _httpClient;
        private readonly IMovieRepository _movieRepository;
        private readonly IObjectMapper<TmdbMoviesApplicationModule> _objectMapper;
        private readonly string tmdbApi = "11004c5dda64d0bae607c7af2636e983";//todo: move to configuration

        public TheMovieDbApiIntegrationService(IMovieRepository movieRepository, IObjectMapper<TmdbMoviesApplicationModule> objectMapper)
        {
            _httpRequestPolicy = Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.InternalServerError)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));
            _httpClient = new HttpClient();
            _movieRepository = movieRepository;
            _objectMapper = objectMapper;
        }

        public async Task<string> GetYoutubeTrailerId(long movieId)
        {
            string requestEndpoint = $"https://api.themoviedb.org/3/movie/{movieId}/videos?api_key={tmdbApi}&language=en-US";

            HttpResponseMessage httpResponse = await _httpRequestPolicy.ExecuteAsync(() => _httpClient.GetAsync(requestEndpoint));
            var content = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<YoutubeTrailerResult>(content);
            if (result != null && result.Results.Count(x => x.Site == "YouTube" && x.Type == "Trailer") > 0)
            {
                return result.Results.First(x => x.Site == "YouTube" && x.Type == "Trailer").Key;
            }
            return "";
        }

        public async Task RetrieveTopRatedMovieResult()
        {
            var page = await _movieRepository.GetNextRetrieverPage();
            if (page == -1) return;

            string requestEndpoint = $"https://api.themoviedb.org/3/movie/top_rated?api_key={tmdbApi}&language=en-US&page={page}";

            HttpResponseMessage httpResponse = await _httpRequestPolicy.ExecuteAsync(() => _httpClient.GetAsync(requestEndpoint));
            var content = await httpResponse.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TopRatedMovieResult>(content);

            var nextPage = await _movieRepository.GetNextRetrieverPage();
            if (nextPage == result.Page)//insert data to database
            {
                var movies = new List<Movie>();
                foreach (var movieResult in result.Results)
                {
                    var movie = _objectMapper.Map<MovieResult, Movie>(movieResult);
                    movie.YoutubeTrailerId = await GetYoutubeTrailerId(movie.MovieId);
                    movie.CreationTime = DateTime.Now;
                    movies.Add(movie);
                }
                await _movieRepository.BulkInsert(movies);
                await _movieRepository.SaveCurrentRetrieverPage(result.Page, result.TotalPages);
            }

        }
    }
}

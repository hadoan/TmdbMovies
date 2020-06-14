using AutoMapper;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
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

        public TheMovieDbApiIntegrationService(IMovieRepository movieRepository, IObjectMapper<TmdbMoviesApplicationModule> objectMapper)
        {
            _httpRequestPolicy = Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.InternalServerError)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));
            _httpClient = new HttpClient();
            _movieRepository = movieRepository;
            _objectMapper = objectMapper;
        }

        public async Task RetrieveTopRatedMovieResult()
        {
            string requestEndpoint = "https://api.themoviedb.org/3/movie/top_rated?api_key=11004c5dda64d0bae607c7af2636e983&language=en-US&page=1"; 

            HttpResponseMessage httpResponse = await _httpRequestPolicy.ExecuteAsync(() => _httpClient.GetAsync(requestEndpoint));
            var content = await httpResponse.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TopRatedMovieResult>(content);

            var nextPage = await _movieRepository.GetNextRetrieverPage();
            if(nextPage == result.Page)//insert data to database
            {
                var movies = new List<Movie>();
                foreach(var movieResult in result.Results)
                {
                    movies.Add(_objectMapper.Map<MovieResult,Movie>(movieResult));
                }
                await _movieRepository.BulkInsert(movies);
                await _movieRepository.SaveCurrentRetrieverPage(result.Page, result.TotalPages);
            }

        }
    }
}

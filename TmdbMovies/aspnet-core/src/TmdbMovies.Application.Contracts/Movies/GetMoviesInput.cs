using Volo.Abp.Application.Dtos;
using System;

namespace TmdbMovies.Movies
{
    public class GetMoviesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public double? PopularityMin { get; set; }
        public double? PopularityMax { get; set; }
        public long? VoteCountMin { get; set; }
        public long? VoteCountMax { get; set; }
        public bool? Video { get; set; }
        public string PosterPath { get; set; }
        public long? MovieIdMin { get; set; }
        public long? MovieIdMax { get; set; }
        public bool? Adult { get; set; }
        public string BackdropPath { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Title { get; set; }
        public double? VoteAverageMin { get; set; }
        public double? VoteAverageMax { get; set; }
        public string Overview { get; set; }
        public DateTime? ReleaseDateMin { get; set; }
        public DateTime? ReleaseDateMax { get; set; }

        public GetMoviesInput()
        {

        }
    }
}
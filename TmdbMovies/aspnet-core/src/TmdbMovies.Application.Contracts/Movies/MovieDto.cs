using System;
using Volo.Abp.Application.Dtos;

namespace TmdbMovies.Movies
{
    public class MovieDto : FullAuditedEntityDto<long>
    {

        public double Popularity { get; set; }

        public long VoteCount { get; set; }

        public bool Video { get; set; }

        public string PosterPath { get; set; }

        public long MovieId { get; set; }

        public bool Adult { get; set; }

        public string BackdropPath { get; set; }

        public string OriginalLanguage { get; set; }

        public string OriginalTitle { get; set; }

        public string Title { get; set; }

        public double VoteAverage { get; set; }

        public string Overview { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string YoutubeTrailerId { get; set; }

        public bool NoYoutubeTrailer { get; set; }

    }
}
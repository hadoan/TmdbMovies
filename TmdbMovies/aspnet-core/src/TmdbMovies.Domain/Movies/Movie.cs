using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace TmdbMovies.Movies
{
    public class Movie : FullAuditedEntity<long>
    {


        public virtual double Popularity { get; set; }

        public virtual long VoteCount { get; set; }

        public virtual bool Video { get; set; }

        [CanBeNull]
        public virtual string PosterPath { get; set; }

        public virtual long MovieId { get; set; }

        public virtual bool Adult { get; set; }

        [CanBeNull]
        public virtual string BackdropPath { get; set; }

        [CanBeNull]
        public virtual string OriginalLanguage { get; set; }

        [CanBeNull]
        public virtual string OriginalTitle { get; set; }

        [CanBeNull]
        public virtual string Title { get; set; }

        public virtual double VoteAverage { get; set; }

        [CanBeNull]
        public virtual string Overview { get; set; }

        public virtual DateTime ReleaseDate { get; set; }

        public string YoutubeTrailerId { get; set; }

        public bool NoYoutubeTrailer { get; set; }

        public Movie()
        {

        }

        public Movie(long id, double popularity, long voteCount, bool video, string posterPath, long movieId, bool adult, string backdropPath, string originalLanguage, string originalTitle, string title, double voteAverage, string overview, DateTime releaseDate)
        {
            Id = id;
            Popularity = popularity;
            VoteCount = voteCount;
            Video = video;
            PosterPath = posterPath;
            MovieId = movieId;
            Adult = adult;
            BackdropPath = backdropPath;
            OriginalLanguage = originalLanguage;
            OriginalTitle = originalTitle;
            Title = title;
            VoteAverage = voteAverage;
            Overview = overview;
            ReleaseDate = releaseDate;

        }
    }
}
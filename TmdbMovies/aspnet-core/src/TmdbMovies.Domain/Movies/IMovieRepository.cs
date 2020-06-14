using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TmdbMovies.Movies
{
    public interface IMovieRepository : IRepository<Movie, long>
    {
        Task<List<Movie>> GetListAsync(
            string filterText = null,
            double? popularityMin = null,
            double? popularityMax = null,
            long? voteCountMin = null,
            long? voteCountMax = null,
            bool? video = null,
            string posterPath = null,
            long? movieIdMin = null,
            long? movieIdMax = null,
            bool? adult = null,
            string backdropPath = null,
            string originalLanguage = null,
            string originalTitle = null,
            string title = null,
            double? voteAverageMin = null,
            double? voteAverageMax = null,
            string overview = null,
            DateTime? releaseDateMin = null,
            DateTime? releaseDateMax = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            double? popularityMin = null,
            double? popularityMax = null,
            long? voteCountMin = null,
            long? voteCountMax = null,
            bool? video = null,
            string posterPath = null,
            long? movieIdMin = null,
            long? movieIdMax = null,
            bool? adult = null,
            string backdropPath = null,
            string originalLanguage = null,
            string originalTitle = null,
            string title = null,
            double? voteAverageMin = null,
            double? voteAverageMax = null,
            string overview = null,
            DateTime? releaseDateMin = null,
            DateTime? releaseDateMax = null,
            CancellationToken cancellationToken = default);
    }
}
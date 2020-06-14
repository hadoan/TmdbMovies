using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using TmdbMovies.EntityFrameworkCore;
using EFCore.BulkExtensions;

namespace TmdbMovies.Movies
{
    public class EfCoreMovieRepository : EfCoreRepository<TmdbMoviesDbContext, Movie, long>, IMovieRepository
    {
        public EfCoreMovieRepository(IDbContextProvider<TmdbMoviesDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Movie>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, popularityMin, popularityMax, voteCountMin, voteCountMax, video, posterPath, movieIdMin, movieIdMax, adult, backdropPath, originalLanguage, originalTitle, title, voteAverageMin, voteAverageMax, overview, releaseDateMin, releaseDateMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MovieConsts.DefaultSorting : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, popularityMin, popularityMax, voteCountMin, voteCountMax, video, posterPath, movieIdMin, movieIdMax, adult, backdropPath, originalLanguage, originalTitle, title, voteAverageMin, voteAverageMax, overview, releaseDateMin, releaseDateMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Movie> ApplyFilter(
            IQueryable<Movie> query,
            string filterText,
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
            DateTime? releaseDateMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.PosterPath.Contains(filterText) || e.BackdropPath.Contains(filterText) || e.OriginalLanguage.Contains(filterText) || e.OriginalTitle.Contains(filterText) || e.Title.Contains(filterText) || e.Overview.Contains(filterText))
                    .WhereIf(popularityMin.HasValue, e => e.Popularity >= popularityMin.Value)
                    .WhereIf(popularityMax.HasValue, e => e.Popularity <= popularityMax.Value)
                    .WhereIf(voteCountMin.HasValue, e => e.VoteCount >= voteCountMin.Value)
                    .WhereIf(voteCountMax.HasValue, e => e.VoteCount <= voteCountMax.Value)
                    .WhereIf(video.HasValue, e => e.Video == video)
                    .WhereIf(!string.IsNullOrWhiteSpace(posterPath), e => e.PosterPath.Contains(posterPath))
                    .WhereIf(movieIdMin.HasValue, e => e.MovieId >= movieIdMin.Value)
                    .WhereIf(movieIdMax.HasValue, e => e.MovieId <= movieIdMax.Value)
                    .WhereIf(adult.HasValue, e => e.Adult == adult)
                    .WhereIf(!string.IsNullOrWhiteSpace(backdropPath), e => e.BackdropPath.Contains(backdropPath))
                    .WhereIf(!string.IsNullOrWhiteSpace(originalLanguage), e => e.OriginalLanguage.Contains(originalLanguage))
                    .WhereIf(!string.IsNullOrWhiteSpace(originalTitle), e => e.OriginalTitle.Contains(originalTitle))
                    .WhereIf(!string.IsNullOrWhiteSpace(title), e => e.Title.Contains(title))
                    .WhereIf(voteAverageMin.HasValue, e => e.VoteAverage >= voteAverageMin.Value)
                    .WhereIf(voteAverageMax.HasValue, e => e.VoteAverage <= voteAverageMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(overview), e => e.Overview.Contains(overview))
                    .WhereIf(releaseDateMin.HasValue, e => e.ReleaseDate >= releaseDateMin.Value)
                    .WhereIf(releaseDateMax.HasValue, e => e.ReleaseDate <= releaseDateMax.Value);
        }

        public async Task<int> GetNextRetrieverPage()
        {
            var lastPage = await this.DbContext.MovieRetrieverHistories.OrderByDescending(x => x.Page).FirstOrDefaultAsync();
            if (lastPage == null) return 1;
            if (lastPage.Page < lastPage.TotalPages) return lastPage.Page + 1;
            //-1: Queried and stored all data
            return -1;
        }

        public async Task SaveCurrentRetrieverPage(int page, int totalPages)
        {
            DbContext.MovieRetrieverHistories.Add(new MovieRetrieverHistory
            {
                Page = page,
                TotalPages = totalPages
            });
            await DbContext.SaveChangesAsync();
        }

        public Task BulkInsert(IList<Movie> movies)
        {
            return DbContext.BulkInsertAsync(movies);
        }

        public Task<Movie> FindByMovieId(long movieId)
        {
            return DbContext.Movies.SingleOrDefaultAsync(x => x.MovieId == movieId);
        }
    }
}
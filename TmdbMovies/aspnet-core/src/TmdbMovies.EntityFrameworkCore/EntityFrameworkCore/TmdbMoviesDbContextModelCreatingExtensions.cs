using Microsoft.EntityFrameworkCore;
using TmdbMovies.Movies;
using Volo.Abp;

namespace TmdbMovies.EntityFrameworkCore
{
    public static class TmdbMoviesDbContextModelCreatingExtensions
    {
        public static void ConfigureTmdbMovies(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<Movie>(b =>
            {
                b.ToTable(TmdbMoviesConsts.DbTablePrefix + "Movies", TmdbMoviesConsts.DbSchema);
            });

            builder.Entity<MovieRetrieverHistory>(b =>
            {
                b.ToTable(TmdbMoviesConsts.DbTablePrefix + "MovieRetrieverHistories", TmdbMoviesConsts.DbSchema);
            });
        }
    }
}
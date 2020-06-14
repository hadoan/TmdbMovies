using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TmdbMovies.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class TmdbMoviesMigrationsDbContextFactory : IDesignTimeDbContextFactory<TmdbMoviesMigrationsDbContext>
    {
        public TmdbMoviesMigrationsDbContext CreateDbContext(string[] args)
        {
            TmdbMoviesEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<TmdbMoviesMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new TmdbMoviesMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}

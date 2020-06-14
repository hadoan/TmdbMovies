using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TmdbMovies.Data;
using Volo.Abp.DependencyInjection;

namespace TmdbMovies.EntityFrameworkCore
{
    public class EntityFrameworkCoreTmdbMoviesDbSchemaMigrator
        : ITmdbMoviesDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreTmdbMoviesDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the TmdbMoviesMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<TmdbMoviesMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
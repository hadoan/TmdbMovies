using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TmdbMovies.Data
{
    /* This is used if database provider does't define
     * ITmdbMoviesDbSchemaMigrator implementation.
     */
    public class NullTmdbMoviesDbSchemaMigrator : ITmdbMoviesDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}
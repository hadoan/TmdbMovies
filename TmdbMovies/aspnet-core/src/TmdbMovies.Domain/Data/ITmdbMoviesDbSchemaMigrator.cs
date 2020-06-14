using System.Threading.Tasks;

namespace TmdbMovies.Data
{
    public interface ITmdbMoviesDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}

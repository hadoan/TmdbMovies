using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace TmdbMovies.EntityFrameworkCore
{
    [DependsOn(
        typeof(TmdbMoviesEntityFrameworkCoreModule)
        )]
    public class TmdbMoviesEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<TmdbMoviesMigrationsDbContext>();
        }
    }
}

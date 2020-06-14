using TmdbMovies.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace TmdbMovies.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(TmdbMoviesEntityFrameworkCoreDbMigrationsModule),
        typeof(TmdbMoviesApplicationContractsModule)
        )]
    public class TmdbMoviesDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}

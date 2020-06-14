using Microsoft.Extensions.DependencyInjection;
using TmdbMovies.Movies;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace TmdbMovies
{
    [DependsOn(
        typeof(TmdbMoviesDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(TmdbMoviesApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class TmdbMoviesApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //
            context.Services.AddAutoMapperObjectMapper<TmdbMoviesApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<TmdbMoviesApplicationModule>();
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.AddBackgroundWorker<RetrievingTopRatedMovieBackgroundWorker>();
        }
    }
}

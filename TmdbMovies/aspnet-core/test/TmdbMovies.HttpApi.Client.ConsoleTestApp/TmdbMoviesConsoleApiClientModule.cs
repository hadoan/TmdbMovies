using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace TmdbMovies.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(TmdbMoviesHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class TmdbMoviesConsoleApiClientModule : AbpModule
    {
        
    }
}

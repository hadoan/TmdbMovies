using Volo.Abp.Modularity;

namespace TmdbMovies
{
    [DependsOn(
        typeof(TmdbMoviesApplicationModule),
        typeof(TmdbMoviesDomainTestModule)
        )]
    public class TmdbMoviesApplicationTestModule : AbpModule
    {

    }
}
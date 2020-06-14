using TmdbMovies.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TmdbMovies
{
    [DependsOn(
        typeof(TmdbMoviesEntityFrameworkCoreTestModule)
        )]
    public class TmdbMoviesDomainTestModule : AbpModule
    {

    }
}
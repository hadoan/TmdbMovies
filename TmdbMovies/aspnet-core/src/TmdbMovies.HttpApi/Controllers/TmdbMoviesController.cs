using TmdbMovies.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TmdbMovies.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class TmdbMoviesController : AbpController
    {
        protected TmdbMoviesController()
        {
            LocalizationResource = typeof(TmdbMoviesResource);
        }
    }
}
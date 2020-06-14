using System;
using System.Collections.Generic;
using System.Text;
using TmdbMovies.Localization;
using Volo.Abp.Application.Services;

namespace TmdbMovies
{
    /* Inherit your application services from this class.
     */
    public abstract class TmdbMoviesAppService : ApplicationService
    {
        protected TmdbMoviesAppService()
        {
            LocalizationResource = typeof(TmdbMoviesResource);
        }
    }
}

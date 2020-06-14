using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TmdbMovies.Movies
{
    public interface ITheMovieDbApiIntegrationService : ITransientDependency
    {
        Task RetrieveTopRatedMovieResult();
    }
}

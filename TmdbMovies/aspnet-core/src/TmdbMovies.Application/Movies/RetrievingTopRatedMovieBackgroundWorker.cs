using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace TmdbMovies.Movies
{
    public class RetrievingTopRatedMovieBackgroundWorker : AsyncPeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private readonly ITheMovieDbApiIntegrationService _theMovieDbApiIntegrationService;
        public RetrievingTopRatedMovieBackgroundWorker(AbpTimer timer, IServiceScopeFactory serviceScopeFactory, ITheMovieDbApiIntegrationService theMovieDbApiIntegrationService) : base(timer, serviceScopeFactory)
        {
            Timer.Period = 10 * 60 * 1000; //run per 10 minutes
            _theMovieDbApiIntegrationService = theMovieDbApiIntegrationService;
        }

        protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
        {
            //retrieve data from api and save to database
            await _theMovieDbApiIntegrationService.RetrieveTopRatedMovieResult();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace TmdbMovies.Movies
{
    public class MovieRetrieverHistory: CreationAuditedEntity<int>
    {
        //get data from which page
        public int Page { get; set; }

        public int TotalPages { get; set; }
    }
}

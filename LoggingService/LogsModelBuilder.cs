using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingService
{
    public class LogsModelBuilder
    {

        public IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);

            builder.EntitySet<Log>(nameof(Log))
                            .EntityType
                            .Filter()
                            .Count()
                            .Expand()
                            .OrderBy()
                            .Page()
                            .Select();

            return builder.GetEdmModel();
        }
    }
}

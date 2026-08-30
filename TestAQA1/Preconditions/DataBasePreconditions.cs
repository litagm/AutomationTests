using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AutomationTests.Modules;

namespace AutomationTests.Preconditions
{
    public class DataBasePreconditions
    {
        public ServiceProvider Provider { get; }

        public DataBasePreconditions()
        {
            var services = new ServiceCollection();
            services.AddDataAccessMarketplace("Data Source=marketplace.db");
            Provider = services.BuildServiceProvider();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace BillingWorkerRole
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            //default
            /*var config = new JobHostConfiguration();

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }

            var host = new JobHost(config);
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();*/

            var config = new JobHostConfiguration("DefaultEndpointsProtocol=https;AccountName=facturagovalblobstorage;AccountKey=tmpnXvGBVUxlPXoQ6qb9lI0GVW2HFnlOx51leqGOC0uaI58fHj7/xmWz64glT1yFIutwedaWTy8CbUb3OOl7eg==;EndpointSuffix=core.windows.net");
            config.Queues.MaxDequeueCount = 10;
            config.UseTimers();
            config.Queues.MaxPollingInterval = TimeSpan.FromSeconds(4);
            config.Queues.BatchSize = 1;
            var host = new JobHost(config);
            host.RunAndBlock();
        }
    }
}

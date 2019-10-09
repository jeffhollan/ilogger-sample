using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(test_ilogger.Startup))]

namespace test_ilogger
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
             // Register services
             
             // You don't need the below line, but if you add it doesn't break with my 
             // current project:
             //
             // builder.Services.AddLogging();
        }
    }

    public class MyFunc
    {
        public MyFunc()
        {

        }
        [FunctionName("MyFunc")]
        public void Run([QueueTrigger("queue", Connection = "AzureWebJobsStorage")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}

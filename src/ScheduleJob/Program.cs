using System;
using Microsoft.Extensions.Hosting;
using Quartz;

namespace ScheduleJob
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I'm Live");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionScopedJobFactory();

                // Create a "key" for the job
                var exchangeRateJobKey = new JobKey("ExchangeRateJob");

                // Register the job with the DI container
                q.AddJob<ExchangeRateJob>(opts => opts.WithIdentity(exchangeRateJobKey));

                // Create a trigger for the job
                q.AddTrigger(opts => opts
                    .ForJob(exchangeRateJobKey) // link to the HelloWorldJob
                    .WithIdentity("job-trigger") // give the trigger a unique name
                    .WithCronSchedule("0/5 * * * * ?")); // run every 5 seconds
                                                         // .StartNow());
            });
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
            // ...
        });
    }
}

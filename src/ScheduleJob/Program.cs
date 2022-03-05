using System;
using DbEntity;
using Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            IConfiguration configuration = hostContext.Configuration;
            var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();

            services.AddSingleton(appSettings);


            services.AddDbContext<DbContextEntity>(dbContextOptions =>
                dbContextOptions.UseSqlServer(appSettings.ConnectionStrings.DefaultConnection)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
            );

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
                                                 // .WithCronSchedule("0/5 * * * * ?")); // run every 5 seconds
                                                 // .WithCronSchedule("0 0 0 * * ?")); // run every day
                    .StartNow());
            });
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        }).ConfigureAppConfiguration((context, builder) =>
        {
            builder.SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json",
             optional: true);
        });
    }
}

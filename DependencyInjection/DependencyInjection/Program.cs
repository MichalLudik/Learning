using DependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddTransient<ITransientService, TransientService>();
            builder.Services.AddTransient<ITransientService, TransientKeyedService>(); //this was keyed service before
            builder.Services.AddKeyedTransient<IExampleService>("fero", (sp, key) => new ExampleService("ahoj"));
            builder.Services.AddTransient<IExampleService>(x => new ExampleService("cusky"));
            builder.Services.AddTransient<IExampleService>(x => new ExampleService("cusky2"));
            builder.Services.AddScoped<IScopedService, ScopedService>();
            builder.Services.AddSingleton<ISingletonService, SingletonService>();
            builder.Services.AddTransient<ServiceLifetimeReporter>();
            using IHost host = builder.Build();

            ShowLifetime(host.Services, "Lifetime 1");
            ShowLifetime(host.Services, "Lifetime 2");

            host.RunAsync();

            static void ShowLifetime(IServiceProvider hostProvider, string lifetime)
            {
                using IServiceScope scope = hostProvider.CreateScope();
                IServiceProvider serviceProvider = scope.ServiceProvider;
                ServiceLifetimeReporter reporter = serviceProvider.GetRequiredService<ServiceLifetimeReporter>();
                reporter.Report($"{lifetime} call 1 to service provider.");

                Console.WriteLine("...");

                reporter = serviceProvider.GetRequiredService<ServiceLifetimeReporter>();
                reporter.Report($"{lifetime} call 2 to service provider.");

                Console.WriteLine();
            }
        }
    }
}

using DependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography.X509Certificates;

namespace DependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // skus si to, ze budes vypisovat spravu a do metody posles bud logger typy console alebo iny message writer
            // tzn bude tam AddSingleton<IMessageLogger, Logger1 / Logger2>
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddTransient<ITransientService, TransientService>();
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
                ServiceLifetimeReporter logger = serviceProvider.GetRequiredService<ServiceLifetimeReporter>();
                logger.Report($"{lifetime} call 1 to service provider.");

                Console.WriteLine("...");

                logger = serviceProvider.GetRequiredService<ServiceLifetimeReporter>();
                logger.Report($"{lifetime} call 2 to service provider.");

                Console.WriteLine();
            }
        }
    }
}

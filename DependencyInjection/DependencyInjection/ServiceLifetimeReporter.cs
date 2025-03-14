using DependencyInjection.Services;

namespace DependencyInjection
{
    public class ServiceLifetimeReporter(
        ITransientService transientService,
        IScopedService scopedService,
        ISingletonService singletonService,
        //[FromKeyedServices("fero")] IExampleService exampleService,
        IEnumerable<IExampleService> exampleServices
        )
    {
        public void Report(string lifetimeDetails)
        {
            // to check how many of registrations of IExampleService exist
            foreach (var service in exampleServices)
            {
                Console.WriteLine(service.Pozdrav());
            }

            // Console.WriteLine(exampleService.Pozdrav());
            Console.WriteLine($"Reporting messages - {lifetimeDetails}");
            LogMessage(transientService, "always new instance");
            LogMessage(scopedService, "same in scope");
            LogMessage(singletonService, "always the same");
        }

        private static void LogMessage<T>(T service, string message) where T : IReportServiceLifetime
        {
            Console.WriteLine($"{typeof(T)}, {service.Id}, {message}, {service.GetType()}");
        }
    }
}

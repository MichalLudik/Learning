using DependencyInjection.Services;

namespace DependencyInjection
{
    public class ServiceLifetimeReporter(
        ITransientService transientService,
        IScopedService scopedService,
        ISingletonService singletonService)
    {
        public void Report(string lifetimeDetails)
        {
            Console.WriteLine($"Reporting messages - {lifetimeDetails}");
            LogMessage(transientService, "always new instance");
            LogMessage(scopedService, "same in scope");
            LogMessage(singletonService, "always the same");
        }

        private static void LogMessage<T>(T service, string message) where T : IReportServiceLifetime
        {
            Console.WriteLine($"{typeof(T)}, {service.Id}, {message}");
        }
    }
}

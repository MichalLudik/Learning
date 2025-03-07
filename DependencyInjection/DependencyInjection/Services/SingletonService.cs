namespace DependencyInjection.Services
{
    public class SingletonService : ISingletonService
    {
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}

namespace DependencyInjection.Services
{
    public class ScopedService : IScopedService
    {
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}

namespace DependencyInjection.Services
{
    internal class TransientKeyedService : ITransientService
    {
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}

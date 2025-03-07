namespace DependencyInjection.Services
{
    public class TransientService : ITransientService
    {
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}

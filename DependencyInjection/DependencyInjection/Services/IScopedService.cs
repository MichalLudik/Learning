using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Services
{
    public interface IScopedService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Scoped;
    }
}

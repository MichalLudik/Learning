using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Services
{
    public interface ISingletonService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Singleton;
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Services
{
    public interface ITransientService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
    }
}

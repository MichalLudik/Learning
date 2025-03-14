using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Services
{
    internal interface ITransientKeyedService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
    }
}

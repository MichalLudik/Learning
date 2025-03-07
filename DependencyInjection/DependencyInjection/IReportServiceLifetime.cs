using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public interface IReportServiceLifetime
    {
        Guid Id { get; }
        ServiceLifetime Lifetime { get; }
    }
}

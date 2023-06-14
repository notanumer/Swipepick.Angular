using Swipepick.Angular.UseCases.Tests.GetTests;

namespace Swipepick.Angular.Web.Infrastructure.DependencyInjection;

public class ApplicationModule
{
    public static void Register(IServiceCollection services)
    {
        services.AddScoped<TestsStatisticService>();
    }
}

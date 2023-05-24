using Swipepick.Angular.UseCases.Tests.CreateTest;

namespace Swipepick.Angular.Web.Infrastructure.DependencyInjection;

internal static class MediatRModule
{
    public static void Register(IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateTestCommand).Assembly));
    }
}

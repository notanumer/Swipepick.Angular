using Swipepick.Angular.UseCases;

namespace Swipepick.Angular.Web.Infrastructure.DependencyInjection;

public class AutoMapperModule
{
    /// <summary>
    /// Register dependencies.
    /// </summary>
    /// <param name="services">Services.</param>
    public static void Register(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(TestMappingProfile).Assembly);
    }
}

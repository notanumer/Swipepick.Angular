using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Swipepick.Angular.Web.Infrastructure.DependencyInjection;
using Xunit;

namespace Swipepick.Angular.Web.Tests;

public class AutoMapperTests
{
    [Fact]
    public void AutoMapper_Configuration_Valid()
    {
        // Arrange
        var sc = new ServiceCollection();
        AutoMapperModule.Register(sc);

        // Act
        var serviceProvider = sc.BuildServiceProvider();
        var mapper = serviceProvider.GetRequiredService<IMapper>();

        // Assert
        mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }
}
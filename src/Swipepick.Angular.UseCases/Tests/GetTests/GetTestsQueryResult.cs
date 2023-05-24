using Swipepick.Angular.DomainServices;

namespace Swipepick.Angular.UseCases.Tests.GetTests;

public record GetTestsQueryResult
{
    public ICollection<TestDto> Tests { get; init; } = new List<TestDto>();
}

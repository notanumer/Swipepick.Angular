using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Test;

namespace Swipepick.Angular.UseCases.Tests.GetTests;

public record GetTestsQueryResult
{
    public ICollection<TestDto> Tests { get; init; } = new List<TestDto>();
}

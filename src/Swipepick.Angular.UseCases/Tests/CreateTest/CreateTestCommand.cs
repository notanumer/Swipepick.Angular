using MediatR;
using Swipepick.Angular.DomainServices;

namespace Swipepick.Angular.UseCases.Tests.CreateTest;

public record CreateTestCommand : IRequest
{
    public string UserEmail { get; init; }

    public TestDto TestDto { get; init; }
}

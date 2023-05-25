using MediatR;

namespace Swipepick.Angular.UseCases.Tests.DeleteTest;

public class DeleteTestCommand : IRequest
{
    required public string Code { get; init; }
}

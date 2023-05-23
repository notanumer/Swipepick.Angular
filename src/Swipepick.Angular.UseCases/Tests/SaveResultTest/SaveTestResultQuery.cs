using MediatR;
using Swipepick.Angular.DomainServices;

namespace Swipepick.Angular.UseCases.Tests.SaveTest;

public class SaveTestResultQuery : IRequest
{
    public StudentAnswerDto StudentAnswer { get; set; }

    public int TestResult { get; set; }
}

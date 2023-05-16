using MediatR;
using Swipepick.Angular.DomainServices;

namespace Swipepick.Angular.UseCases.Tests.GetTestResult;

public record GetTestResultCommand(string TestCode, StudentAnswerDto StudentAnswer) : IRequest<int>;

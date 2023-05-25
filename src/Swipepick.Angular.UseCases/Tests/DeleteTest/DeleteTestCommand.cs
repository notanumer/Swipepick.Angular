using MediatR;

namespace Swipepick.Angular.UseCases.Tests.DeleteTest;

public record DeleteTestCommand(string UserEmail, string Code) : IRequest;

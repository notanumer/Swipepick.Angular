using MediatR;

namespace Swipepick.Angular.UseCases.Tests.GetTests;

public record GetTestsQuery(string UserEmail) : IRequest<GetTestsQueryResult>;

using MediatR;
using Swipepick.Angular.DomainServices;

namespace Swipepick.Angular.UseCases.Tests.GetTestByCode;

public record GetTestByCodeQuery(string UniqueCode) : IRequest<TestDto>;

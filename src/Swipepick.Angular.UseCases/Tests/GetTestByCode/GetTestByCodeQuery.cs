using MediatR;
using Swipepick.Angular.UseCases.Tests.GetTestByCode.Dto;

namespace Swipepick.Angular.UseCases.Tests.GetTestByCode;

public record GetTestByCodeQuery(string UniqueCode) : IRequest<TestDto>;

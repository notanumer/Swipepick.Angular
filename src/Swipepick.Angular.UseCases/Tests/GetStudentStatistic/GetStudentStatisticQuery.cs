using MediatR;

namespace Swipepick.Angular.UseCases.Tests.GetStudentStatistic;

public record GetStudentStatisticQuery(string TestCode) : IRequest<IEnumerable<GetStudentStatisticDto>>;

using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Question;

namespace Swipepick.Angular.UseCases.Tests.GetStudentStatistic;

public class GetStudentStatisticResult
{
    public ICollection<GetStudentStatisticDto> StudentStatistic { get; set; } = new List<GetStudentStatisticDto>();

    public ICollection<QuestionStatisticDto> TestResult { get; set; } = new List<QuestionStatisticDto>();

    required public string TestTitle { get; set; }
}

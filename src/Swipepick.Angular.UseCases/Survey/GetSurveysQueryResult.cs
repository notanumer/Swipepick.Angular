using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Question;

namespace Swipepick.Angular.UseCases.Survey;

public class GetSurveysQueryResult
{
    public ICollection<SurveyStatisticDto> Surveys { get; init; } = new List<SurveyStatisticDto>();
}

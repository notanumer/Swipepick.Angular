using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Question;

namespace Swipepick.Angular.UseCases.Tests.GetTests.Dto.Test;

public class TestStatisticDto
{
    required public string Title { get; init; }

    required public string UniqueCode { get; init; }

    required public DateOnly CreatedAt { get; init; }

    public double CorrectAnswersPercent { get; set; }

    public ICollection<QuestionStatisticDto> QuestionStatistics { get; set; } = new List<QuestionStatisticDto>();
}

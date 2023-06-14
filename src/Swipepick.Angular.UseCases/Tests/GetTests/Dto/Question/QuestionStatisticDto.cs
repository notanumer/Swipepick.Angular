using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Answer;

namespace Swipepick.Angular.UseCases.Tests.GetTests.Dto.Question;

public class QuestionStatisticDto
{
    public int QuestionId { get; set; }

    public double WrongAnswersPercent { get; set; }

    public double CorrectAnswersPercent { get; set; }

    required public string QuestionContent { get; set; }

    public AnswerStatisticDto AnswerStatistic { get; set; }

    public int CorrectAnswersCount { get; set; }

    public int CorrectAnswer { get; set; }
}

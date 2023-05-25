namespace Swipepick.Angular.UseCases.Tests.GetTests.Dto.Question;

public class QuestionStatisticDto
{
    public int QuestionId { get; set; }

    public double WrongAnswersPercent { get; set; }

    public double CorrectAnswersPercent { get; set; }
}

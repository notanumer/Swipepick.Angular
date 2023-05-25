namespace Swipepick.Angular.UseCases.Tests.GetTests.Dto.Question;

public class QuestionStatisticDto
{
    public int QuestionId { get; set; }

    public int WrongAnswersPercent { get; set; }

    public int CorrectAnswersPercent { get; set; }
}

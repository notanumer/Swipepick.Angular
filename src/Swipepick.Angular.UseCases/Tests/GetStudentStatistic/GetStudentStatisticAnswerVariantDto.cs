namespace Swipepick.Angular.UseCases.Tests.GetStudentStatistic;

public class GetStudentStatisticAnswerVariantDto
{
    public int Variant { get; init; }

    public int QuestionId { get; init; }

    required public string AnswerContent { get; init; }

    public bool IsCorrect { get; set; }
}

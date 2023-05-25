namespace Swipepick.Angular.UseCases.Tests.GetTestByCode.Dto;

public class QuestionDto
{
    required public string QuestionContent { get; init; }

    required public AnswerDto Answer { get; init; }
}

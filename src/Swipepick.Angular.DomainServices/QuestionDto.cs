namespace Swipepick.Angular.DomainServices;

public record QuestionDto
{
    required public string QuestionContent { get; init; }

    required public AnswerDto Answer { get; init; }
}

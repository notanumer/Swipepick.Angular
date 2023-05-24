namespace Swipepick.Angular.DomainServices;

public record QuestionDto
{
    required public string QuestionContent { get; init; }

    public ICollection<AnswerDto> Answers { get; init; } = new List<AnswerDto>();
}

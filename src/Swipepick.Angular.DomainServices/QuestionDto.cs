namespace Swipepick.Angular.DomainServices;

public record QuestionDto
{
    public string QuestionContent { get; init; }

    public ICollection<AnswerDto> Answers { get; init; } = new List<AnswerDto>();
}

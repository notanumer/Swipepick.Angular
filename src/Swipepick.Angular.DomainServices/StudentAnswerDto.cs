namespace Swipepick.Angular.DomainServices;

public record StudentAnswerDto
{
    public string TestCode { get; init; }

    public List<SelectedAnswerDto> SelectedAnswers { get; init; }
}

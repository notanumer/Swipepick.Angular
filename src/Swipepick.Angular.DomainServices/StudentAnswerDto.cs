namespace Swipepick.Angular.DomainServices;

public record StudentAnswerDto
{
    required public string TestCode { get; init; }

    public ICollection<SelectedAnswerDto> SelectedAnswers { get; init; } = new List<SelectedAnswerDto>();

    required public string Name { get; init; }

    required public string Lastname { get; init; }
}

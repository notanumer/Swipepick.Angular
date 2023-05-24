namespace Swipepick.Angular.DomainServices;

public record TestDto
{
    required public string Title { get; init; }

    public ICollection<StudentDto> Students { get; init; } = new List<StudentDto>();

    public ICollection<QuestionDto> Questions { get; init; } = new List<QuestionDto>();
}

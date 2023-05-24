namespace Swipepick.Angular.UseCases.Tests.GetTestByCode.Dto;

public class TestDto
{
    required public string Title { get; set; }

    public ICollection<QuestionDto> Questions { get; init; } = new List<QuestionDto>();
}

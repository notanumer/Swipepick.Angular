namespace Swipepick.Angular.UseCases.Tests.GetTestByCode.Dto;

public class TestDto
{
    public string Title { get; set; }

    public List<QuestionDto> Questions { get; init; }
}

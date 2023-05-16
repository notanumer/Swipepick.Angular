namespace Swipepick.Angular.UseCases.Tests.GetTestByCode.Dto;

public class TestDto
{
    public List<DomainServices.StudentDto> Students { get; init; }

    public List<QuestionDto> Questions { get; init; }
}

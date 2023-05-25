namespace Swipepick.Angular.UseCases.Tests.GetTests.Dto.Student;

public record StudentAnswerDto
{
    public ICollection<StudentAnswerVariantDto> Answers { get; init; } = new List<StudentAnswerVariantDto>();
}

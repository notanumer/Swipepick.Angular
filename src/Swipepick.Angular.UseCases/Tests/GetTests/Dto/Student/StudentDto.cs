using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Question;

namespace Swipepick.Angular.UseCases.Tests.GetTests.Dto.Student;

public record StudentDto
{
    required public string Name { get; init; }

    required public string Lastname { get; init; }

    public int TestResult { get; init; }

    public ICollection<QuestionDto> Questions { get; private set; } = new List<QuestionDto>();

    required public StudentAnswerDto StudentAnswer { get; set; }
}

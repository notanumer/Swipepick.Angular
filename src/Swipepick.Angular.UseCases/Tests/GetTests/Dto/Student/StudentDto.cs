namespace Swipepick.Angular.UseCases.Tests.GetTests.Dto.Student;

public record StudentDto
{
    required public string Name { get; init; }

    required public string Lastname { get; init; }

    public int TestResult { get; init; }

    required public StudentAnswerDto StudentAnswer { get; set; }
}

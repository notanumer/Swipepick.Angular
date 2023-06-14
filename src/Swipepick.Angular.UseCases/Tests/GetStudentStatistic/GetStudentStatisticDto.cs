namespace Swipepick.Angular.UseCases.Tests.GetStudentStatistic;

public class GetStudentStatisticDto
{
    public string Name { get; init; }

    public string Lastname { get; init; }

    public int TestResult { get; init; }

    public DateTime CreatedAt { get; init; }

    public int TestQuestionsCount { get; set; }

    public GetStudentStatisticAnswerDto StudentAnswer { get; init; }
}

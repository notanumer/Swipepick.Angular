using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Answer;

namespace Swipepick.Angular.UseCases.Tests.GetTests.Dto.Question;

public record QuestionDto
{
    public int Id { get; init; }

    required public string QuestionContent { get; init; }

    required public AnswerDto Answer { get; init; }

    required public string CorrectAnswerContent { get; init; }
}

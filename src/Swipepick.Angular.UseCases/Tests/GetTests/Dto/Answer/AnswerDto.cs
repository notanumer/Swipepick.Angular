namespace Swipepick.Angular.UseCases.Tests.GetTests.Dto.Answer;

public class AnswerDto
{
    public ICollection<AnswerVariantDto> AnswerVariants { get; init; } = new List<AnswerVariantDto>();

    public int CorrectAnswer { get; init; }
}
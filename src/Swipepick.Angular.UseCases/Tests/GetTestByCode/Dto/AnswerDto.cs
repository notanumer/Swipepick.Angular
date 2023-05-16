namespace Swipepick.Angular.UseCases.Tests.GetTestByCode.Dto;

public class AnswerDto
{
    public ICollection<AnswerVariantDto> AnswerVariants { get; init; } = new List<AnswerVariantDto>();

    public int QuestionId { get; init; }
}

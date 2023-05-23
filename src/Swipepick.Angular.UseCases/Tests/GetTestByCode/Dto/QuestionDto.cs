namespace Swipepick.Angular.UseCases.Tests.GetTestByCode.Dto;

public class QuestionDto
{
    public int QuestionId { get; init; }

    public string QuestionContent { get; init; }

    public ICollection<AnswerDto> Answers { get; init; } = new List<AnswerDto>();
}

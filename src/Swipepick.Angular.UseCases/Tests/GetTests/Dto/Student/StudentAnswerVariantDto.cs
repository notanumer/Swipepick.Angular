namespace Swipepick.Angular.UseCases.Tests.GetTests.Dto.Student;

public record StudentAnswerVariantDto
{
    public int StudentAnswerId { get; set; }

    public int Variant { get; set; }

    public int QuestionId { get; set; }

    required public string AnswerContent { get; set; }
}


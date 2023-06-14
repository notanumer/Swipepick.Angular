namespace Swipepick.Angular.UseCases.Tests.GetStudentStatistic;

public class GetStudentStatisticAnswerDto
{
    public ICollection<GetStudentStatisticAnswerVariantDto> Answers { get; set; } = new List<GetStudentStatisticAnswerVariantDto>();
}

using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Answer;

namespace Swipepick.Angular.UseCases.Tests.GetTests.Dto.Question;

public class AnswerStatisticDto
{
    public ICollection<AnswerVariantStatisticDto> AnswerVariants { get; set; }
        = new List<AnswerVariantStatisticDto>();
}
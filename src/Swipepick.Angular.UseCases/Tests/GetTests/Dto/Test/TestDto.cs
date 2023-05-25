using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Question;
using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Student;

namespace Swipepick.Angular.UseCases.Tests.GetTests.Dto.Test;

public record TestDto
{
    required public string Title { get; init; }

    required public string UniqueCode { get; init; }

    required public DateOnly CreatedAt { get; init; }

    public ICollection<StudentDto> Students { get; init; } = new List<StudentDto>();

    public ICollection<QuestionDto> Questions { get; init; } = new List<QuestionDto>();
}

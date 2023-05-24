using Swipepick.Angular.DomainServices;

namespace Swipepick.Angular.UseCases.Tests.CreateTest;

public record CreateTestDto
{
    required public string Title { get; init; }

    public ICollection<QuestionDto> Questions { get; init; } = new List<QuestionDto>();
}

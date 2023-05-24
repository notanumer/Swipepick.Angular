namespace Swipepick.Angular.DomainServices;

public record StudentDto
{
    required public string Name { get; init; }

    required public string Lastname { get; init; }

    public int TestResult { get; init; }
}

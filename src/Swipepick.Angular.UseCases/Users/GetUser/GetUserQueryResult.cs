namespace Swipepick.Angular.UseCases.Users.GetUser;

public record GetUserQueryResult
{
    public string UserEmail { get; init; }

    public string Token { get; init; }
}

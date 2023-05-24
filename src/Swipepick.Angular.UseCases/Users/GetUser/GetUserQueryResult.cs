namespace Swipepick.Angular.UseCases.Users.GetUser;

public record GetUserQueryResult
{
    required public string UserEmail { get; init; }

    required public string Token { get; init; }
}

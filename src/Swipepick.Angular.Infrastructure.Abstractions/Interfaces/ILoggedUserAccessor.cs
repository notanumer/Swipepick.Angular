namespace Swipepick.Angular.Infrastructure.Abstractions.Interfaces;

public interface ILoggedUserAccessor
{
    bool IsAuthenticated();

    string GetUserEmail();
}

using MediatR;

namespace Swipepick.Angular.UseCases.Users.GetUser;

public record GetUserQuery : IRequest<GetUserQueryResult>
{
    required public string Email { get; init; }

    required public string Password { get; init; }
}

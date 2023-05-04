using MediatR;
using Swipepick.Angular.DomainServices;

namespace Swipepick.Angular.UseCases.Users.GetUser;

public record GetUserQuery : IRequest<GetUserQueryResult>
{
    public string Email { get; init; }

    public string Password { get; init; }
}

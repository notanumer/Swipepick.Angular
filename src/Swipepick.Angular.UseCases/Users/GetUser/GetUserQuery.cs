using MediatR;
using Swipepick.Angular.DomainServices;

namespace Swipepick.Angular.UseCases.Users.GetUser;

public record GetUserQuery : IRequest<GetUserQueryResult>
{
    public UserLoginDto UserLoginDto { get; init; }
}

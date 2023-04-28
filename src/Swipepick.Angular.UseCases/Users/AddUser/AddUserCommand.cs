using MediatR;
using Swipepick.Angular.DomainServices;

namespace Swipepick.Angular.UseCases.Users.AddUser
{
    public record AddUserCommand : IRequest
    {
        public UserDto User { get; init; } 
    }
}

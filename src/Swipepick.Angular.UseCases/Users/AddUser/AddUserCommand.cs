using MediatR;

namespace Swipepick.Angular.UseCases.Users.AddUser
{
    public record AddUserCommand : IRequest
    {
        public string Email { get; init; }

        public string Password { get; init; }

        public string Name { get; init; }

        public string LastName { get; init; }
    }
}

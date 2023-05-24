using MediatR;

namespace Swipepick.Angular.UseCases.Users.AddUser;

public record AddUserCommand : IRequest
{
    required public string Email { get; init; }

    required public string Password { get; init; }

    required public string Name { get; init; }

    required public string LastName { get; init; }
}

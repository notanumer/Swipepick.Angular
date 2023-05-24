using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swipepick.Angular.UseCases.Users.AddUser;
using Swipepick.Angular.UseCases.Users.GetUser;

namespace Swipepick.Angular.Web.Controllers;

[ApiController]
[Route("api/auth")]
public class UserAuthController : Controller
{
    private readonly IMediator mediator;

    public UserAuthController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<GetUserQueryResult> Login(GetUserQuery query, CancellationToken cancellationToken = default)
         => await mediator.Send(query, cancellationToken);

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task Register(AddUserCommand addUserCommand)
        => await mediator.Send(addUserCommand);
}

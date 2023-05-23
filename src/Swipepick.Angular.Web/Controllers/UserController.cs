using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Swipepick.Angular.Web.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : Controller
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [Authorize]
    [HttpGet("get-email")]
    public IActionResult GetEmail()
    {
        var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
        return Json(new { email = email.Value });
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Swipepick.Angular.Web.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : Controller
{
    //[Authorize]
    //[HttpGet("email")]
    //public IActionResult GetEmail()
    //{
    //    var email = User.Claims.First(x => x.Type == ClaimTypes.Email);
    //    return Json(new { email = email.Value });
    //}
}

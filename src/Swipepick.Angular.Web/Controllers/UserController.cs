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

    //[Authorize]
    //[HttpGet("get-tests")]
    //public IActionResult Test()
    //{
    //    var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
    //    var tests = _user.GetTests(email.Value);
    //    return Ok(tests);
    //}

    [Authorize]
    [HttpGet("get-email")]
    public IActionResult GetEmail()
    {
        var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
        return Json(new { email = email.Value });
    }

    //[Authorize]
    //[HttpGet("test-urls")]
    //public IActionResult GetTestsUrls()
    //{
    //    var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
    //    var urls = new List<string>();
    //    var tests = _user.GetTests(email.Value);
    //    foreach (var test in tests)
    //    {
    //        urls.Add(test.Url);
    //    }
    //    return Ok(urls);
    //}
}

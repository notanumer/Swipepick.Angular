using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swipepick.Angular.DomainServices;
using Swipepick.Angular.UseCases.Tests.CreateTest;
using Swipepick.Angular.UseCases.Tests.GetTestByCode;
using Swipepick.Angular.UseCases.Tests.GetTestResult;
using Swipepick.Angular.UseCases.Tests.GetTests;
using Swipepick.Angular.UseCases.Tests.GetTestsUrls;
using Swipepick.Angular.UseCases.Tests.SaveTest;
using System.Security.Claims;

namespace Swipepick.Angular.Web.Controllers;

[ApiController]
[Route("api/tests")]
public class TestController : Controller
{
    private readonly IMediator mediator;

    public TestController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("create")]
    [Authorize]
    public async Task<IActionResult> Create(
        CreateTestCommand createTestCommand,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(createTestCommand, cancellationToken);
        return Ok();
    }

    [AllowAnonymous]
    [HttpGet("{uniqueCode}")]
    public async Task<IActionResult> GetTest(
        [FromRoute] string uniqueCode,
        CancellationToken cancellationToken = default)
    {
        var test = await mediator.Send(new GetTestByCodeQuery(uniqueCode), cancellationToken);

        if (test == null)
            return BadRequest("Test not found");

        var quest = test.Questions
            .Select(x => new
            {
                QueId = x.QuestionId,
                Question = x.QuestionContent,
                Options = test.Questions.Select(q => q.Answers)
            }).OrderBy(y => Guid.NewGuid());

        return Json(test.Questions.OrderBy(y => Guid.NewGuid()));
    }

    [AllowAnonymous]
    [HttpPost("submit-answers")]
    public async Task<IActionResult> SubmitAnswers(
        [FromBody] StudentAnswerDto studentAnswer,
        CancellationToken cancellationToken = default)
    {
        var count = await mediator.Send(new GetTestResultCommand(studentAnswer.TestCode, studentAnswer), cancellationToken);
        await mediator.Send(new SaveTestResultQuery() { StudentAnswer = studentAnswer, TestResult = count }, cancellationToken);
        return Ok(count);
    }

    [Authorize]
    [HttpGet("get-tests")]
    public async Task<IActionResult> GetTests(CancellationToken cancellationToken)
    {
        var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
        var tests = await mediator.Send(new GetTestsQuery(email), cancellationToken);
        return Ok(tests);
    }

    [Authorize]
    [HttpGet("test-urls")]
    public async Task<IActionResult> GetTestsUrls(CancellationToken cancellationToken)
    {
        var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
        var urls = await mediator.Send(new GetTestsUrlsQuery() { UserEmail = email }, cancellationToken);
        return Ok(urls);
    }
}

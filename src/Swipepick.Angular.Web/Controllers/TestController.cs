using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swipepick.Angular.DomainServices;
using Swipepick.Angular.UseCases.Survey;
using Swipepick.Angular.UseCases.Tests.CreateTest;
using Swipepick.Angular.UseCases.Tests.DeleteTest;
using Swipepick.Angular.UseCases.Tests.GetStudentStatistic;
using Swipepick.Angular.UseCases.Tests.GetTestByCode;
using Swipepick.Angular.UseCases.Tests.GetTestResult;
using Swipepick.Angular.UseCases.Tests.GetTests;
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
    public async Task<string> Create(CreateTestCommand createTestCommand, CancellationToken cancellationToken)
        => await mediator.Send(createTestCommand, cancellationToken);

    [AllowAnonymous]
    [HttpGet("{uniqueCode}")]
    public async Task<IActionResult> GetTest([FromRoute] string uniqueCode, CancellationToken cancellationToken)
    {
        var test = await mediator.Send(new GetTestByCodeQuery(uniqueCode), cancellationToken);
        return Json(test.Questions.OrderBy(y => Guid.NewGuid()));
    }

    [AllowAnonymous]
    [HttpPost("submit-answers")]
    public async Task<IActionResult> SubmitAnswers(StudentAnswerDto studentAnswer, CancellationToken cancellationToken)
    {
        var count = await mediator.Send(new GetTestResultCommand(studentAnswer.TestCode, studentAnswer), cancellationToken);
        await mediator.Send(new SaveTestResultQuery { StudentAnswer = studentAnswer, TestResult = count }, cancellationToken);
        return Ok(count);
    }

    [Authorize]
    [HttpGet]
    public async Task<GetTestsQueryResult> GetTests(CancellationToken cancellationToken)
    {
        var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)!.Value;
        return await mediator.Send(new GetTestsQuery(email), cancellationToken);
    }

    [Authorize]
    [HttpGet("surveys")]
    public async Task<GetSurveysQueryResult> GetSurveys(CancellationToken cancellationToken)
    {
        var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)!.Value;
        return await mediator.Send(new GetSurveysQuery(email), cancellationToken);
    }

    [Authorize]
    [HttpDelete("{uniqueCode}")]
    public async Task DeleteTest([FromRoute] string uniqueCode, CancellationToken cancellationToken)
    {
        var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)!.Value;
        await mediator.Send(new DeleteTestCommand(email, uniqueCode), cancellationToken);
    }

    [Authorize]
    [HttpGet("students-statistic/{uniqueCode}")]
    public async Task<GetStudentStatisticResult> GetStudentStatistic([FromRoute] string uniqueCode, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetStudentStatisticQuery(uniqueCode), cancellationToken);
    }
}

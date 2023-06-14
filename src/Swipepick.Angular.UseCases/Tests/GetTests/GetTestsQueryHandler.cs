using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Swipepick.Angular.Infrastructure.Abstractions.Exceptions;
using Swipepick.Angular.Infrastructure.Abstractions.Interfaces;
using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Question;
using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Test;

namespace Swipepick.Angular.UseCases.Tests.GetTests;

public class GetTestsQueryHandler : IRequestHandler<GetTestsQuery, GetTestsQueryResult>
{
    private readonly IAppDbContext appDbContext;
    private readonly IMapper mapper;
    private readonly TestsStatisticService statisticService;

    public GetTestsQueryHandler(
        IAppDbContext appDbContext,
        IMapper mapper,
        TestsStatisticService statisticService)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
        this.statisticService = statisticService;
    }

    public async Task<GetTestsQueryResult> Handle(GetTestsQuery request, CancellationToken cancellationToken)
    {
        var user = await appDbContext.Users
            .FirstOrDefaultAsync(u => u.Email == request.UserEmail, cancellationToken)
            ?? throw new UserNotFoundException($"User with email {request.UserEmail} not found.");

        var tests = appDbContext.Tests
            .Where(x => x.UserId == user.Id)
            .ProjectTo<TestDto>(mapper.ConfigurationProvider);

        var testsStatistics = new List<TestStatisticDto>();
        foreach (var test in tests)
        {
            var testStatistic = new TestStatisticDto
            {
                CreatedAt = test.CreatedAt,
                Title = test.Title,
                UniqueCode = test.UniqueCode
            };

            testStatistic.QuestionStatistics = statisticService.GetQuestionsStatistics(test);
            testsStatistics.Add(testStatistic);
        }

        return new GetTestsQueryResult()
        {
            Tests = testsStatistics
        };
    }
}

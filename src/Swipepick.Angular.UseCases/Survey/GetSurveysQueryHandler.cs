using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Swipepick.Angular.Infrastructure.Abstractions.Exceptions;
using Swipepick.Angular.Infrastructure.Abstractions.Interfaces;
using Swipepick.Angular.UseCases.Tests.GetTests;
using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Test;

namespace Swipepick.Angular.UseCases.Survey;

internal class GetSurveysQueryHandler : IRequestHandler<GetSurveysQuery, GetSurveysQueryResult>
{
    private readonly IAppDbContext appDbContext;
    private readonly IMapper mapper;
    private readonly TestsStatisticService statisticService;

    public GetSurveysQueryHandler(
        IAppDbContext appDbContext,
        IMapper mapper,
        TestsStatisticService statisticService)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
        this.statisticService = statisticService;
    }

    public async Task<GetSurveysQueryResult> Handle(GetSurveysQuery request, CancellationToken cancellationToken)
    {
        var user = await appDbContext.Users
            .FirstOrDefaultAsync(u => u.Email == request.UserEmail, cancellationToken)
            ?? throw new UserNotFoundException($"User with email {request.UserEmail} not found.");

        var surveys = appDbContext.Tests
            .Where(x => x.UserId == user.Id)
            .Where(x => x.IsSurvey == true)
            .ProjectTo<TestDto>(mapper.ConfigurationProvider);

        var surveysStatistics = new List<SurveyStatisticDto>();
        foreach (var survey in surveys)
        {
            var surveyStatistic = new SurveyStatisticDto
            {
                CreatedAt = survey.CreatedAt,
                Title = survey.Title,
                UniqueCode = survey.UniqueCode
            };

            foreach (var question in survey.Questions)
            {
                surveyStatistic.QuestionStatistics.Add(statisticService.GetAnswerStatistic(survey, question));
            }
            
            surveysStatistics.Add(surveyStatistic);
        }

        return new GetSurveysQueryResult
        {
            Surveys = surveysStatistics
        };
    }
}

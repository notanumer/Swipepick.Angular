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

    public GetTestsQueryHandler(IAppDbContext appDbContext, IMapper mapper)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
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

            var questionsStatistics = new List<QuestionStatisticDto>();
            foreach (var question in test.Questions)
            {
                var correctAnswer = question.Answer.CorrectAnswer;
                var allAnswers = test.Students
                    .Select(s => s.StudentAnswer)
                    .Count();
                var correctAnswers = test.Students
                    .SelectMany(s => s.StudentAnswer.Answers)
                    .Where(sa => sa.QuestionId == question.Id && sa.Variant == correctAnswer)
                    .Count();

                var wrongAnswers = allAnswers - correctAnswers;
                var wrongAnswersPercent = (double)wrongAnswers / allAnswers * 100;
                var questionStatistic = new QuestionStatisticDto()
                {
                    QuestionId = question.Id,
                    WrongAnswersPercent = wrongAnswersPercent,
                    CorrectAnswersPercent = 100 - wrongAnswersPercent
                };

                questionsStatistics.Add(questionStatistic);
            }
            testStatistic.QuestionStatistics = questionsStatistics;
            testsStatistics.Add(testStatistic);
        }

        return new GetTestsQueryResult()
        {
            Tests = testsStatistics
        };
    }
}

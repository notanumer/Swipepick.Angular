using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Swipepick.Angular.Infrastructure.Abstractions.Interfaces;
using Swipepick.Angular.UseCases.Tests.GetTests;
using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Test;

namespace Swipepick.Angular.UseCases.Tests.GetStudentStatistic;

internal class GetStudentStatisticQueryHandler : IRequestHandler<GetStudentStatisticQuery, GetStudentStatisticResult>
{
    private readonly IAppDbContext appDbContext;
    private readonly IMapper mapper;
    private readonly TestsStatisticService statisticService;

    public GetStudentStatisticQueryHandler(IAppDbContext appDbContext,
        IMapper mapper,
        TestsStatisticService statisticService)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
        this.statisticService = statisticService;
    }

    public async Task<GetStudentStatisticResult> Handle(GetStudentStatisticQuery request, CancellationToken cancellationToken)
    {
        var test = await appDbContext.Tests
            .Include(t => t.Students)
            .ThenInclude(s => s.StudentAnswer)
            .ThenInclude(sa => sa.Answers)
            .Include(t => t.Questions)
            .ThenInclude(q => q.Answer)
            .ThenInclude(a => a!.AnswerVariants)
            .FirstAsync(t => t.UniqueCode == request.TestCode, cancellationToken);

        var students = await appDbContext.Students
            .Where(s => s.TestId == test.Id)
            .ProjectTo<GetStudentStatisticDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        foreach (var student in students)
        {
            student.TestQuestionsCount = test.Questions.Count;
            foreach (var studentAnswer in student.StudentAnswer.Answers)
            {
                foreach (var question in test.Questions)
                {
                    if (question.CorrectAnswerContent == studentAnswer.AnswerContent)
                    {
                        studentAnswer.IsCorrect = true;
                    }
                }
            }
        }

        var testDto = mapper.Map<TestDto>(test);
        var result = new GetStudentStatisticResult()
        {
            StudentStatistic = students,
            TestResult = statisticService.GetQuestionsStatistics(testDto),
            TestTitle = test.Title  
        };

        return result;
    }
}

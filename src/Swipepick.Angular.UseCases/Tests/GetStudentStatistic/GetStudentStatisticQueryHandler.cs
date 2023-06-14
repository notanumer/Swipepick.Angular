using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Swipepick.Angular.Infrastructure.Abstractions.Interfaces;

namespace Swipepick.Angular.UseCases.Tests.GetStudentStatistic;

internal class GetStudentStatisticQueryHandler : IRequestHandler<GetStudentStatisticQuery, IEnumerable<GetStudentStatisticDto>>
{
    private readonly IAppDbContext appDbContext;
    private readonly IMapper mapper;

    public GetStudentStatisticQueryHandler(IAppDbContext appDbContext, IMapper mapper)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<GetStudentStatisticDto>> Handle(GetStudentStatisticQuery request, CancellationToken cancellationToken)
    {
        var test = await appDbContext.Tests
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
        return students;
    }
}

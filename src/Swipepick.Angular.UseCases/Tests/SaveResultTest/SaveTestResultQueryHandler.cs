using MediatR;
using Microsoft.EntityFrameworkCore;
using Swipepick.Angular.Domain;
using Swipepick.Angular.Infrastructure.Abstractions.Interfaces;

namespace Swipepick.Angular.UseCases.Tests.SaveTest;

public class SaveTestResultQueryHandler : IRequestHandler<SaveTestResultQuery>
{
    private readonly IAppDbContext appDbContext;
    private readonly IMediator mediator;

    public SaveTestResultQueryHandler(IAppDbContext appDbContext, IMediator mediator)
    {
        this.appDbContext = appDbContext;
        this.mediator = mediator;
    }

    public async Task Handle(SaveTestResultQuery request, CancellationToken cancellationToken)
    {
        var test = await appDbContext.Tests.FirstAsync(t => t.UniqueCode == request.StudentAnswer.TestCode, cancellationToken);
        var student = new Student()
        {
            Lastname = request.StudentAnswer.Lastname,
            Name = request.StudentAnswer.Name,
            UserId = test.UserId,
            TestId = test.Id,
            TestResult = request.TestResult,
        };
        var studentAnswers = new List<StudentAnswer>();
        foreach (var studentAnswer in request.StudentAnswer.SelectedAnswers)
        {
            var variants = request.StudentAnswer.SelectedAnswers.Select(a => new StudentAnswerVariant() { Variant = a.AnswerCode }).ToList();
            var answer = new StudentAnswer() { Student = student, Answers = variants };
            studentAnswers.Add(answer);
        }
        student.StudentAnswers = studentAnswers;
        appDbContext.Students.Add(student);
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}

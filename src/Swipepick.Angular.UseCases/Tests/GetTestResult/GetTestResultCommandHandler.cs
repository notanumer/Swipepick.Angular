using MediatR;
using Microsoft.EntityFrameworkCore;
using Swipepick.Angular.Infrastructure.Abstractions.Interfaces;

namespace Swipepick.Angular.UseCases.Tests.GetTestResult;

public class GetTestResultCommandHandler : IRequestHandler<GetTestResultCommand, int>
{
    private readonly IAppDbContext appDbContext;

    public GetTestResultCommandHandler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<int> Handle(GetTestResultCommand request, CancellationToken cancellationToken)
    {
        var currentAnsws = request.StudentAnswer.SelectedAnswers.GroupBy(x => x.QuestionId);

        var test = await appDbContext.Tests
            .Include(t => t.Questions)
            .ThenInclude(q => q.Answers)
            .ThenInclude(a => a.AnswerVariants)
            .FirstAsync(t => t.UniqueCode == request.TestCode, cancellationToken);

        var count = 0;
        var correctAnsw = test.Questions
            .Select(x => x.Answers.First())
            .GroupBy(x => x.QuestionId);

        foreach (var t in currentAnsws)
        {
            var group = correctAnsw.Single(g => g.Key == t.Key);
            var y = currentAnsws.Single(g => g.Key == t.Key);
            var currentAns = y.Select(x => x).First();
            var tight = group.Select(x => x).First();
            if (tight.CorrectAnswer == currentAns.AnswerCode)
            {
                count++;
            }
        }

        return count;
    }
}

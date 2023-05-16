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
        var currectAnsw = request.StudentAnswer.SelectedAnswers.GroupBy(x => x.QuestionId);
        var test = await appDbContext.Tests.FirstAsync(t => t.UniqueCode == request.TestCode, cancellationToken);
        var questions = test.Questions.Select(x => x).ToList();
        var count = 0;
        var correctAnsw = questions.Select(x => x.Answers.First()).GroupBy(x => x.QuestionId);
        foreach (var t in currectAnsw)
        {
            var group = correctAnsw.Single(g => g.Key == t.Key);
            var y = currectAnsw.Single(g => g.Key == t.Key);
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

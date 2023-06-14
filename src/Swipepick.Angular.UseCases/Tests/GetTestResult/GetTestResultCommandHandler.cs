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
        var selectedAnswersByQuestionGroups = request.StudentAnswer.SelectedAnswers.GroupBy(x => x.QuestionId);

        var test = await appDbContext.Tests
            .Include(t => t.Questions)
            .ThenInclude(q => q.Answer)
            .ThenInclude(a => a.AnswerVariants)
            .FirstAsync(t => t.UniqueCode == request.TestCode, cancellationToken);

        var count = 0;
        var answersByQuestionGroups = test.Questions
            .Select(x => x.Answer)
            .GroupBy(x => x!.QuestionId);

        foreach (var slectedAnswers in selectedAnswersByQuestionGroups)
        {
            var answersByQuestion = answersByQuestionGroups.Single(g => g.Key == slectedAnswers.Key);
            var selectedAnswersByQuestion = selectedAnswersByQuestionGroups.Single(g => g.Key == slectedAnswers.Key);
            var currentAnswer = selectedAnswersByQuestion.Select(x => x).First();
            var rightAnswer = answersByQuestion.Select(x => x).First();
            if (rightAnswer.CorrectAnswer == currentAnswer.AnswerCode)
            {
                count++;
            }
        }

        return count;
    }
}

using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Question;
using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Test;

namespace Swipepick.Angular.UseCases.Tests.GetTests;

public class TestsStatisticService
{
    internal List<QuestionStatisticDto> GetQuestionsStatistics(TestDto test)
    {
        var questionsStatistics = new List<QuestionStatisticDto>();

        var allAnswersCount = test.Students
                .Select(s => s.StudentAnswer)
                .Count();

        var t = GetAnswerStatistic(test);

        foreach (var question in test.Questions)
        {
            var questionAnswers = question.Answer.AnswerVariants;

            var correctAnswer = question.Answer.CorrectAnswer;

            if (allAnswersCount == 0)
            {
                questionsStatistics.Add(new QuestionStatisticDto()
                {
                    QuestionId = question.Id,
                    WrongAnswersPercent = 0,
                    CorrectAnswersPercent = 0,
                    QuestionContent = question.QuestionContent
                });

                continue;
            }

            var correctAnswers = test.Students
                .SelectMany(s => s.StudentAnswer.Answers)
                .Where(sa => sa.QuestionId == question.Id && sa.Variant == correctAnswer)
                .Count();

            var answerStatistic = new AnswerStatisticDto();
            

            var wrongAnswers = allAnswersCount - correctAnswers;
            var wrongAnswersPercent = Math.Round((double)wrongAnswers / allAnswersCount * 100);
            var questionStatistic = new QuestionStatisticDto()
            {
                QuestionId = question.Id,
                WrongAnswersPercent = wrongAnswersPercent,
                CorrectAnswersPercent = 100 - wrongAnswersPercent,
                QuestionContent = question.QuestionContent,
                AnswerStatistic = answerStatistic
            };

            questionsStatistics.Add(questionStatistic);
        }

        return questionsStatistics;
    }

    private AnswerStatisticDto GetAnswerStatistic(TestDto test)
    {
        var answersByQuestions = test.Students
            .SelectMany(x => x.StudentAnswer.Answers)
            .GroupBy(y => y.QuestionId)
            .ToDictionary(k => k.Key);

        var variantsByQuestions = new Dictionary<int, List<string>>();
        foreach (var question in test.Questions)
        {
            var questionContent = question.Id;
            var variants = question.Answer.AnswerVariants.Select(x => x.Variant).ToList();
            variantsByQuestions.Add(questionContent, variants);
        }

        var answerStatistic = new AnswerStatisticDto();
        return answerStatistic;
        
    }
}

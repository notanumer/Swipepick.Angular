using Swipepick.Angular.UseCases.Tests.GetTests.Dto.Answer;
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
                    QuestionContent = question.QuestionContent,
                    CorrectAnswer = correctAnswer,
                    CorrectAnswersCount = 0
                });

                continue;
            }

            var correctAnswers = test.Students
                .SelectMany(s => s.StudentAnswer.Answers)
                .Where(sa => sa.QuestionId == question.Id && sa.Variant == correctAnswer)
                .Count();

            var answerStatistic = GetAnswerStatistic(test, question);

            var wrongAnswers = allAnswersCount - correctAnswers;
            var wrongAnswersPercent = Math.Round((double)wrongAnswers / allAnswersCount * 100);
            var correctVariant = new AnswerVariantDto(question.CorrectAnswerContent);
            var correctAnswerIndex = Array.IndexOf(question.Answer.AnswerVariants.ToArray(), correctVariant);
            var questionStatistic = new QuestionStatisticDto()
            {
                QuestionId = question.Id,
                WrongAnswersPercent = wrongAnswersPercent,
                CorrectAnswersPercent = 100 - wrongAnswersPercent,
                QuestionContent = question.QuestionContent,
                AnswerStatistic = answerStatistic,
                CorrectAnswersCount = correctAnswers,
                CorrectAnswer = correctAnswerIndex
            };

            questionsStatistics.Add(questionStatistic);
        }

        return questionsStatistics;
    }

    public AnswerStatisticDto GetAnswerStatistic(TestDto test, QuestionDto question)
    {
        var studentAnswersByQuestions = test.Students
            .SelectMany(x => x.StudentAnswer.Answers)
            .GroupBy(y => y.QuestionId)
            .ToDictionary(k => k.Key);

        var answersStatistic = new AnswerStatisticDto();
        var variantsCounts = new Dictionary<string, int>();
        var studentAnswersGroup = studentAnswersByQuestions[question.Id];
        var studentsAnswersCount = studentAnswersGroup.Count();
        foreach (var answer in question.Answer.AnswerVariants)
        {
            variantsCounts.Add(answer.Variant, 0);
            foreach (var studentAnswer in studentAnswersGroup)
            {
                if (answer.Variant == studentAnswer.AnswerContent)
                {
                    variantsCounts[answer.Variant]++;
                }
            }
        }

        foreach (var key in variantsCounts.Keys)
        {
            if (variantsCounts[key] == 0)
            {
                answersStatistic.AnswerVariants.Add(new AnswerVariantStatisticDto(key, 0));
                continue;
            }
            var answerPercent = Math.Round((double)variantsCounts[key] / studentsAnswersCount * 100);
            var answerStatisticDto = new AnswerVariantStatisticDto(key, answerPercent);
            answersStatistic.AnswerVariants.Add(answerStatisticDto);
        }

        return answersStatistic;

    }
}

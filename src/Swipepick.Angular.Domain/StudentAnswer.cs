using System.ComponentModel.DataAnnotations;

namespace Swipepick.Angular.Domain;

public class StudentAnswer
{
    [Key]
    public int Id { get; set; }

    public int StudentId { get; set; }

    public Student? Student { get; set; }

    public int QuestionId { get; set; }

    public Question? Question { get; set; }

    public ICollection<StudentAnswerVariant> Answers { get; set; } = new List<StudentAnswerVariant>();

}
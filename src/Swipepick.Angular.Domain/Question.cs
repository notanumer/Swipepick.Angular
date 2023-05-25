using System.ComponentModel.DataAnnotations;

namespace Swipepick.Angular.Domain;

public class Question
{
    [Key]
    public int Id { get; set; }

    public int TestId { get; set; }

    public ICollection<Student> Students { get; private set; } = new List<Student>();

    public Test? Test { get; set; }

    required public string QuestionContent { get; set; }

    public Answer? Answer { get; set; }
}

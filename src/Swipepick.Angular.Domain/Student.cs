using System.ComponentModel.DataAnnotations;

namespace Swipepick.Angular.Domain;

public class Student
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    required public string Name { get; set; }

    required public string Lastname { get; set; }

    public StudentAnswer? StudentAnswer { get; set; }

    public User? User { get; set; }

    public Test? Test { get; set; }

    public ICollection<Question> Questions { get; private set; } = new List<Question>();

    public int TestId { get; set; }

    public int TestResult { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace Swipepick.Angular.Domain;

public class Test
{
    [Key]
    public int Id { get; set; }

    required public string Title { get; set; }

    required public string UniqueCode { get; set; }

    public int UserId { get; set; }

    public ICollection<Question> Questions { get; set; } = new List<Question>();

    public User? User { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();
}
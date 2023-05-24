using System.ComponentModel.DataAnnotations;

namespace Swipepick.Angular.Domain;

public class User
{
    [Key]
    public int Id { get; set; }

    required public string Name { get; set; }

    required public string Lastname { get; set; }

    required public string Email { get; set; }

    required public byte[] PasswordHash { get; set; }

    required public byte[] PasswordSalt { get; set; }

    public ICollection<Test> Tests { get; set; } = new List<Test>();

    public ICollection<Student> Students { get; set; } = new List<Student>();
}

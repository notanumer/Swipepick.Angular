using System.ComponentModel.DataAnnotations;

namespace Swipepick.Angular.Domain;

public class AnswerVariant
{
    [Key]
    public int Id { get; set; }

    public Answer? Answer { get; set; }

    required public string Variant { get; set; }
}

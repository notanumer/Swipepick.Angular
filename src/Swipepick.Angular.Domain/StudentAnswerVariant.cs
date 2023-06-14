using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swipepick.Angular.Domain
{
    public class StudentAnswerVariant
    {
        [Key]
        public int Id { get; set; }

        public StudentAnswer? Answer { get; set; }

        public int StudentAnswerId { get; set; }

        public Question? Question { get; set; }

        public int QuestionId { get; set; }

        public int Variant { get; set; }

        required public string AnswerContent { get; set; }
    }
}

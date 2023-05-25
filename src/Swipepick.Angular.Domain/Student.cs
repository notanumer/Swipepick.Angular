﻿using System.ComponentModel.DataAnnotations;

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

    public int QuestionId { get; set; }

    public Question? Question { get; set; }

    public int TestId { get; set; }

    public int TestResult { get; set; }
}

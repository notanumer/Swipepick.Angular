using Microsoft.EntityFrameworkCore;
using Swipepick.Angular.Domain;
using Swipepick.Angular.Infrastructure.Abstractions.Interfaces;

namespace Swipepick.Angular.DataAccess;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Test> Tests { get; set; }

    public DbSet<Answer> Answers { get; set; }

    public DbSet<StudentAnswer> StudentAnswers { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Question> Questions { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="options">The options to be used by a <see cref="Microsoft.EntityFrameworkCore.DbContext" />.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Question>()
            .HasOne(que => que.Answer)
            .WithOne(answ => answ.Question)
            .HasForeignKey<Answer>(a => a.QuestionId);

        modelBuilder.Entity<Test>()
            .HasOne(owner => owner.User)
            .WithMany(user => user.Tests)
            .HasForeignKey(fk => fk.UserId);
        modelBuilder.Entity<Test>().Property(test => test.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Test>().HasIndex(test => test.UniqueCode).IsUnique();

        modelBuilder.Entity<Question>()
            .HasOne(b => b.Test)
            .WithMany(c => c.Questions)
            .HasForeignKey(fk => fk.TestId);
        modelBuilder.Entity<Question>().Property(que => que.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Student>()
            .HasOne(b => b.StudentAnswer)
            .WithOne(c => c.Student)
            .HasForeignKey<StudentAnswer>(g => g.StudentId);
        modelBuilder.Entity<StudentAnswer>().Property(sa => sa.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Student>()
            .HasOne(user => user.User)
            .WithMany(user => user.Students)
            .HasForeignKey(fk => fk.UserId);
        modelBuilder.Entity<Student>().Property(student => student.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Student>()
            .HasOne(student => student.Test)
            .WithMany(test => test.Students);

        modelBuilder.Entity<User>()
            .HasIndex(user => user.Email).IsUnique();

        modelBuilder.Entity<Answer>()
            .HasMany(a => a.AnswerVariants)
            .WithOne(v => v.Answer);
    }
}

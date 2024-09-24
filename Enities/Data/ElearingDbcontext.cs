using Entites.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entites.Data
{
    public class ElearingDbcontext:IdentityDbContext<User>
    {
        public ElearingDbcontext(DbContextOptions<ElearingDbcontext> options):base(options)
        {

        }    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //User Table
            builder.Entity<User>()
                 .HasMany<Course>()
                 .WithOne()
                 .HasForeignKey(x=>x.InstractourId);

            builder.Entity<User>()
                .HasMany<Enrolment>()
                .WithOne()
                .HasForeignKey(f => f.UserId);

            builder.Entity<User>()
                .HasMany<Question>()
                .WithOne()
                .HasForeignKey(f=>f.UserId);

            builder.Entity<User>()
                .HasMany<Answer>()
                .WithOne()
                .HasForeignKey(f => f.UserId);

            builder.Entity<User>()
                .HasMany<Payment>()
                .WithOne()
                .HasForeignKey(f => f.UserId);

            builder.Entity<User>()
                .HasMany<Withdrow>()
                .WithOne()
                .HasForeignKey(f => f.UserId);

            builder.Entity<User>()
                .HasMany<Deposit>()
                .WithOne()
                .HasForeignKey(f => f.UserId);

            builder.Entity<User>()
                .HasMany<Note>()
                .WithOne()
                .HasForeignKey(f => f.UserId);

            builder.Entity<User>()
                .HasMany<Progress>()
                .WithOne()
                .HasForeignKey(f => f.UserId);

            //Course Table
            builder.Entity<Course>()
                .HasMany<Enrolment>()
                .WithOne()
                .HasForeignKey(f => f.CourseId);

            builder.Entity<Course>()
                .HasMany<Module>()
                .WithOne()
                .HasForeignKey(f => f.CourseId);

            builder.Entity<Course>()
                .HasMany<Question>()
                .WithOne()
                .HasForeignKey(f => f.CourseId);

            builder.Entity<Course>()
                .HasMany<Anouncment>()
                .WithOne()
                .HasForeignKey(f => f.CourseId);

            builder.Entity<Course>()
                .HasMany<Payment>()
                .WithOne()
                .HasForeignKey(f => f.CourseId);

            //Enrollment Table
            builder.Entity<Enrolment>()
                .HasKey(f => new { f.UserId, f.CourseId });

            //Module Table
            builder.Entity<Module>()
                .HasMany<Lesson>()
                .WithOne()
                .HasForeignKey(f => f.ModuleId);

            //Lesson Table
            builder.Entity<Lesson>()
                .HasMany<Material>()
                .WithOne()
                .HasForeignKey(f => f.LessonId);

            builder.Entity<Lesson>()
                .HasMany<Question>()
                .WithOne()
                .HasForeignKey(f => f.LessonId);

            builder.Entity<Lesson>()
                .HasMany<Note>()
                .WithOne()
                .HasForeignKey(f => f.LessonId);

            builder.Entity<Lesson>()
                .HasMany<Progress>()
                .WithOne()
                .HasForeignKey(f => f.LessonId);

            //Question Table
            builder.Entity<Question>()
                .HasMany<Answer>()
                .WithOne()
                .HasForeignKey(f => f.QuestionId);

            //Progress Table
            builder.Entity<Progress>()
                .HasKey(f => new {f.UserId,f.LessonId}); 
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Anouncment> Anouncments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Withdrow> Withdrows { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Progress> Progresses { get; set; }
    }
}

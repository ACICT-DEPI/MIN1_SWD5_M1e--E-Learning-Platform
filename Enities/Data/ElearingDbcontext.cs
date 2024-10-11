using Enities.Models;
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
                 .HasMany<Course>(c=>c.Courses)
                 .WithOne(c=>c.User)
                 .HasForeignKey(x => x.InstractourId);

            builder.Entity<User>()
                .HasMany<Enrolment>(u=>u.Enrolments)
                .WithOne(e=>e.User)
                .HasForeignKey(f => f.UserId);

            builder.Entity<User>()
                .HasMany<Question>(u=>u.Questions)
                .WithOne(q=>q.User)
                .HasForeignKey(f=>f.UserId);

            builder.Entity<User>()
                .HasMany<Answer>(u=>u.Answers)
                .WithOne(a=>a.User)
                .HasForeignKey(f => f.UserId);

            builder.Entity<User>()
                .HasMany<Payment>(u=>u.Payments)
                .WithOne(p=>p.User)
                .HasForeignKey(f => f.UserId);

            builder.Entity<User>()
                .HasMany<Withdrow>(u=>u.Withdrows)
                .WithOne(w=>w.User)
                .HasForeignKey(f => f.UserId);

            builder.Entity<User>()
                .HasMany<Deposit>(u=>u.Deposits)
                .WithOne(d=>d.User)
                .HasForeignKey(f => f.UserId);

            builder.Entity<User>()
                .HasMany<Note>(u=>u.Notes)
                .WithOne(n=>n.User)
                .HasForeignKey(f => f.UserId);

            builder.Entity<User>()
                .HasMany<Progress>(u=>u.Progresses)
                .WithOne(p=>p.User)
                .HasForeignKey(f => f.UserId);

			builder.Entity<User>()
				.HasMany<Review>(u => u.Reviews)
				.WithOne(r => r.User)
				.HasForeignKey(f => f.UserId);

			//Course Table
			builder.Entity<Course>()
                .HasMany<Enrolment>(c=>c.Enrolments)
                .WithOne(e=>e.Course)
                .HasForeignKey(f => f.CourseId);

            builder.Entity<Course>()
                .HasMany<Module>(c=>c.Modules)
                .WithOne(m=>m.Course)
                .HasForeignKey(f => f.CourseId);

            builder.Entity<Course>()
                .HasMany<Question>(c=>c.Questions)
                .WithOne(q=>q.Course)
                .HasForeignKey(f => f.CourseId);

            builder.Entity<Course>()
                .HasMany<Anouncment>(c=>c.Anouncments)
                .WithOne(a=>a.Course)
                .HasForeignKey(f => f.CourseId);

            builder.Entity<Course>()
                .HasMany<Payment>(c=>c.Payments)
                .WithOne(p=>p.Course)
                .HasForeignKey(f => f.CourseId);

			builder.Entity<Course>()
				.HasMany<Review>(c => c.Reviews)
				.WithOne(r => r.Course)
				.HasForeignKey(f => f.CourseId);

			//Enrollment Table
			builder.Entity<Enrolment>()
                .HasKey(f => new { f.UserId, f.CourseId });

            //Module Table
            builder.Entity<Module>()
                .HasMany<Lesson>(m=>m.Lessons)
                .WithOne(l=>l.Module)
                .HasForeignKey(f => f.ModuleId);

            //Lesson Table
            builder.Entity<Lesson>()
                .HasMany<Material>(l=>l.Materials)
                .WithOne(m=>m.Lesson)
                .HasForeignKey(f => f.LessonId);

            builder.Entity<Lesson>()
                .HasMany<Question>(l=>l.Questions)
                .WithOne(q=>q.Lesson)
                .HasForeignKey(f => f.LessonId);

            builder.Entity<Lesson>()
                .HasMany<Note>(l=>l.Notes)
                .WithOne(n=>n.Lesson)
                .HasForeignKey(f => f.LessonId);

            builder.Entity<Lesson>()
                .HasMany<Progress>(l=>l.Progresss)
                .WithOne(p=>p.Lesson)
                .HasForeignKey(f => f.LessonId);

            //Question Table
            builder.Entity<Question>()
                .HasMany<Answer>(q=>q.Answers)
                .WithOne(a=>a.Question)
                .HasForeignKey(f => f.QuestionId);

            //Progress Table
            builder.Entity<Progress>()
                .HasKey(f => new {f.UserId,f.LessonId});
            
            //Review Table
			builder.Entity<Review>()
				.HasKey(R => new { R.UserId, R.CourseId });
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
        public DbSet<Review> Reviews { get; set; }
    }
}

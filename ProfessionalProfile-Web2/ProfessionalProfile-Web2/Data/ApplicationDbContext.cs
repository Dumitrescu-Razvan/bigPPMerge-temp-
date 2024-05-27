using Microsoft.EntityFrameworkCore;
using ProfessionalProfile_Web2.Models;

namespace ProfessionalProfile_Web2.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<AssessmentResult> AssessmentResults { get; set; }
        public DbSet<BussinesCard> BussinesCards { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Education> Educations { get; set; }


        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AssessmentTest> AssessmentTests { get; set; }
        public DbSet<Privacy> Privacies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Endorsement> Endorsements { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Volunteering> Volunteerings { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Endorsement>(Endorsement =>
            {
                Endorsement.HasKey(a => a.endorsementId);
                Endorsement.HasOne(a => a.Endorser)
                    .WithMany()
                    .HasForeignKey(a => a.endorserId)
                    .OnDelete(DeleteBehavior.Restrict);


                Endorsement.HasOne(a => a.Recipient)
                    .WithMany()
                    .HasForeignKey(a => a.recipientid)
                    .OnDelete(DeleteBehavior.Restrict);


            });

            modelBuilder.Entity<Privacy>().HasOne(a => a.User).WithOne(a => a.Privacy)
                .HasForeignKey<Privacy>(a => a.userId);
            modelBuilder.Entity<AssessmentTest>(AssessmentTest =>
            {
                AssessmentTest.HasKey(a => a.assessmentTestId);
                AssessmentTest.HasOne(a => a.User)
                    .WithMany()
                    .HasForeignKey(a => a.userId);
                AssessmentTest.HasOne(a => a.Skill)
                    .WithMany()
                    .HasForeignKey(a => a.skillid);
            });
            modelBuilder.Entity<Question>(Question =>
            {
                Question.HasKey(a => a.questionId);
                Question.HasOne(a => a.AssessmentTest)
                    .WithMany()
                    .HasForeignKey(a => a.assesmentTestId);
            });

            modelBuilder.Entity<Answer>(Answer =>
            {
                Answer.HasKey(a => a.answerId);
                Answer.HasOne(a => a.Question)
                    .WithMany()
                    .HasForeignKey(a => a.questionId);
            });
            modelBuilder.Entity<Education>(Education =>
            {

                Education.HasKey(a => a.educationId);
                Education.HasOne(a => a.User)
                    .WithMany()
                    .HasForeignKey(a => a.userId);
            });
            modelBuilder.Entity<Certificate>(Certificate =>
            {
                Certificate.HasKey(a => a.certificateId);
                Certificate.HasOne(a => a.User)
                    .WithMany()
                    .HasForeignKey(a => a.userId);
            });
            modelBuilder.Entity<BussinesCard>(BussinesCard => { BussinesCard.HasKey(a => a.bcId); });
            modelBuilder.Entity<AssessmentResult>(AssessmentResult =>
            {
                AssessmentResult.HasKey(a => a.assesmentResultId);
                AssessmentResult.HasOne(a => a.AssessmentTest)
                    .WithOne(a => a.AssessmentResult)
                    .HasForeignKey<AssessmentResult>(a => a.assesmentTestId).OnDelete(DeleteBehavior.NoAction);

                AssessmentResult.HasOne(a => a.User)
                    .WithOne(a => a.AssessmentResult).HasForeignKey<AssessmentResult>(a => a.userId)
                    .OnDelete(DeleteBehavior.NoAction);


            });
            modelBuilder.Entity<Project>(Project =>
            {
                Project.HasKey(a => a.projectId);
                Project.HasOne(a => a.User)
                    .WithOne(a => a.Project)
                    .HasForeignKey<Project>(b => b.userId);
            });

            modelBuilder.Entity<Volunteering>(Volunteering =>
            {
                Volunteering.HasKey(a => a.volunteeringId);
                Volunteering.HasOne(a => a.User)
                    .WithOne(a => a.Volunteering)
                    .HasForeignKey<Volunteering>(a => a.userId);
            });

            modelBuilder.Entity<WorkExperience>(WorkExperience =>
            {
                WorkExperience.HasKey(a => a.workId);
                WorkExperience.HasOne(a => a.User)
                    .WithOne(a => a.WorkExperience)
                    .HasForeignKey<WorkExperience>(a => a.userId);
            });
        }
    }
}

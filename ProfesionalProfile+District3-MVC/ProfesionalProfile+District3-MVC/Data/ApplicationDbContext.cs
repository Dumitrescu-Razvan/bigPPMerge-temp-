using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProfesionalProfile_District3_MVC.Models;


namespace ProfesionalProfile_District3_MVC.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // <------------------------------------ ProfesionalProfile_District3_MVC ------------------------------------>

        public DbSet<AssessmentResult> AssessmentResults { get; set; }
        public DbSet<BusinessCard> BusinessCards { get; set; }
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




        // <------------------------------------ District3 ------------------------------------>

        public DbSet<Account> Account { get; set; }
        public DbSet<BlockedProfile> BlockedProfile { get; set; }
        public DbSet<CloseFriendProfile> CloseFriendProfile { get; set; }
        public DbSet<FancierProfile>? FancierProfile { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Highlight> Highlight { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // <------------------------------------ ProfesionalProfile_District3_MVC ------------------------------------>

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
            modelBuilder.Entity<BusinessCard>(BusinessCard => { BusinessCard.HasKey(a => a.bcId); });
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

            // <------------------------------------ District3 ------------------------------------>

            modelBuilder.Entity<Account>(account =>
            {
                account.HasKey(e => e.Id);
                account.HasOne(e => e.User)
                    .WithOne()
                    .HasForeignKey<Account>(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<BlockedProfile>(blockedProfile =>
            {
                blockedProfile.HasKey(e => e.Id);
                blockedProfile.HasOne(e => e.User)
                    .WithOne()
                    .HasForeignKey<BlockedProfile>(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<CloseFriendProfile>(closeFriendProfile =>
            {
                closeFriendProfile.HasKey(e => e.Id);
                closeFriendProfile.HasOne(e => e.User)
                    .WithOne()
                    .HasForeignKey<CloseFriendProfile>(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<FancierProfile>().HasKey(x => x.ProfileId);
            modelBuilder.Entity<Group>(group =>
            {
                group.HasKey(e => e.Id);

            });
            modelBuilder.Entity<Highlight>(highlight =>
            {
                highlight.HasKey(e => e.HighlightId);
                highlight.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId);
            });
            modelBuilder.Entity<Post>().HasKey(x => x.Id);
            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(e => e.Id);
                user.HasOne(e => e.Group)
                    .WithMany(g => g.GroupMembers)
                    .HasForeignKey(e => e.GroupId);
            });
        }
        
        // <------------------------------------ Securistii ------------------------------------>
        public DbSet<Location> Location { get; set; }
        public DbSet<Media> Media { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<PostArchived> PostArchived { get; set; } = null!;
        public DbSet<PostSaved> PostSaved { get; set; } = null!;
        public DbSet<PostReported> PostReported { get; set; } = null!;
        public DbSet<Block> Block { get; set; } = null!;
        public DbSet<Follow> Follow { get; set; } = null!;
        public DbSet<FeedConfiguration> FeedConfigurations { get; set; } = null!;
        public DbSet<ControversialFeed> ControversialFeeds { get; set; } = null!;
        public DbSet<TrendingFeed> TrendingFeeds { get; set; } = null!;
        public DbSet<FollowedFeedFollowedUsers> FollowedFeedFollowedUsers { get; set; } = null!;
        public DbSet<FollowingFeed> FollowingFeeds { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<FollowSuggestion> FollowSuggestions { get; set; } = null!;

        public DbSet<Request> Requests { get; set; } = null!;
    }
}

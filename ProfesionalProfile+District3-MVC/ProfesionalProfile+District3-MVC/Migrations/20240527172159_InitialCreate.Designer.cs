﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProfesionalProfile_District3_MVC.Data;

#nullable disable

namespace ProfesionalProfile_District3_MVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240527172159_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cvv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpirationDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Account");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Answer", b =>
                {
                    b.Property<int>("answerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("answerId"));

                    b.Property<string>("answerText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("questionId")
                        .HasColumnType("int");

                    b.HasKey("answerId");

                    b.HasIndex("questionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.AssessmentResult", b =>
                {
                    b.Property<int>("assesmentResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("assesmentResultId"));

                    b.Property<int>("assesmentTestId")
                        .HasColumnType("int");

                    b.Property<int>("score")
                        .HasColumnType("int");

                    b.Property<DateTime>("testDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("assesmentResultId");

                    b.HasIndex("assesmentTestId")
                        .IsUnique();

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("AssessmentResults");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.AssessmentTest", b =>
                {
                    b.Property<int>("assessmentTestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("assessmentTestId"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("skillid")
                        .HasColumnType("int");

                    b.Property<string>("testName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("assessmentTestId");

                    b.HasIndex("skillid");

                    b.HasIndex("userId");

                    b.ToTable("AssessmentTests");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.BlockedProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BlockDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("BlockedProfile");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.BussinesCard", b =>
                {
                    b.Property<int>("bcId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bcId"));

                    b.Property<string>("summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uniqueUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("bcId");

                    b.HasIndex("userId");

                    b.ToTable("BussinesCards");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Certificate", b =>
                {
                    b.Property<int>("certificateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("certificateId"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("expirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("issuedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("issuedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("certificateId");

                    b.HasIndex("userId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.CloseFriendProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CloseFriendedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("CloseFriendProfile");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Education", b =>
                {
                    b.Property<int>("educationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("educationId"));

                    b.Property<string>("degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fieldOfStudy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("graduationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("institution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("educationId");

                    b.HasIndex("userId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Endorsement", b =>
                {
                    b.Property<int>("endorsementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("endorsementId"));

                    b.Property<int>("endorserId")
                        .HasColumnType("int");

                    b.Property<int>("recipientid")
                        .HasColumnType("int");

                    b.Property<int>("skillId")
                        .HasColumnType("int");

                    b.HasKey("endorsementId");

                    b.HasIndex("endorserId");

                    b.HasIndex("recipientid");

                    b.HasIndex("skillId");

                    b.ToTable("Endorsements");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.FancierProfile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfileId"));

                    b.Property<string>("DailyMotto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FrameNumber")
                        .HasColumnType("int");

                    b.Property<string>("Hashtag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Links")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveMottoDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProfileId");

                    b.ToTable("FancierProfile");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Highlight", b =>
                {
                    b.Property<int>("HighlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HighlightId"));

                    b.Property<string>("CoverFilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostsIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("HighlightId");

                    b.HasIndex("UserId");

                    b.ToTable("Highlight");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Notification", b =>
                {
                    b.Property<int>("notificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("notificationId"));

                    b.Property<string>("activity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isRead")
                        .HasColumnType("bit");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("notificationId");

                    b.HasIndex("userId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Privacy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("CanViewCertificates")
                        .HasColumnType("bit");

                    b.Property<bool>("CanViewEducation")
                        .HasColumnType("bit");

                    b.Property<bool>("CanViewProjects")
                        .HasColumnType("bit");

                    b.Property<bool>("CanViewSkills")
                        .HasColumnType("bit");

                    b.Property<bool>("CanViewVolunteering")
                        .HasColumnType("bit");

                    b.Property<bool>("CanViewWorkExperience")
                        .HasColumnType("bit");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("Privacies");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Project", b =>
                {
                    b.Property<int>("projectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("projectId"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("projectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("technologies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("projectId");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Question", b =>
                {
                    b.Property<int>("questionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("questionId"));

                    b.Property<int>("assesmentTestId")
                        .HasColumnType("int");

                    b.Property<string>("questionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("questionId");

                    b.HasIndex("assesmentTestId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Skill", b =>
                {
                    b.Property<int>("skillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("skillId"));

                    b.Property<int?>("BussinesCardbcId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("skillId");

                    b.HasIndex("BussinesCardbcId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConfirmationPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DarkTheme")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FollowersCount")
                        .HasColumnType("int");

                    b.Property<int?>("FollowingCount")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("UserSession")
                        .HasColumnType("time");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsiteURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Volunteering", b =>
                {
                    b.Property<int>("volunteeringId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("volunteeringId"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("organisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("volunteeringId");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("Volunteerings");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.WorkExperience", b =>
                {
                    b.Property<int>("workId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("workId"));

                    b.Property<string>("achievements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employmentPeriod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("jobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("responsibilities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("workId");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("WorkExperiences");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Account", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("ProfesionalProfile_District3_MVC.Models.Account", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Answer", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("questionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.AssessmentResult", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.AssessmentTest", "AssessmentTest")
                        .WithOne("AssessmentResult")
                        .HasForeignKey("ProfesionalProfile_District3_MVC.Models.AssessmentResult", "assesmentTestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "User")
                        .WithOne("AssessmentResult")
                        .HasForeignKey("ProfesionalProfile_District3_MVC.Models.AssessmentResult", "userId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AssessmentTest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.AssessmentTest", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("skillid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.BlockedProfile", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("ProfesionalProfile_District3_MVC.Models.BlockedProfile", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.BussinesCard", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Certificate", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.CloseFriendProfile", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("ProfesionalProfile_District3_MVC.Models.CloseFriendProfile", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Education", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Endorsement", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "Endorser")
                        .WithMany()
                        .HasForeignKey("endorserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "Recipient")
                        .WithMany()
                        .HasForeignKey("recipientid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProfesionalProfile_District3_MVC.Models.Skill", null)
                        .WithMany("endorsements")
                        .HasForeignKey("skillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endorser");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Highlight", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Notification", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", null)
                        .WithMany("Notifications")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Privacy", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "User")
                        .WithOne("Privacy")
                        .HasForeignKey("ProfesionalProfile_District3_MVC.Models.Privacy", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Project", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "User")
                        .WithOne("Project")
                        .HasForeignKey("ProfesionalProfile_District3_MVC.Models.Project", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Question", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.AssessmentTest", "AssessmentTest")
                        .WithMany()
                        .HasForeignKey("assesmentTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssessmentTest");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Skill", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.BussinesCard", null)
                        .WithMany("keySkills")
                        .HasForeignKey("BussinesCardbcId");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.User", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.Group", "Group")
                        .WithMany("GroupMembers")
                        .HasForeignKey("GroupId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Volunteering", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "User")
                        .WithOne("Volunteering")
                        .HasForeignKey("ProfesionalProfile_District3_MVC.Models.Volunteering", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.WorkExperience", b =>
                {
                    b.HasOne("ProfesionalProfile_District3_MVC.Models.User", "User")
                        .WithOne("WorkExperience")
                        .HasForeignKey("ProfesionalProfile_District3_MVC.Models.WorkExperience", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.AssessmentTest", b =>
                {
                    b.Navigation("AssessmentResult")
                        .IsRequired();
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.BussinesCard", b =>
                {
                    b.Navigation("keySkills");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Group", b =>
                {
                    b.Navigation("GroupMembers");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.Skill", b =>
                {
                    b.Navigation("endorsements");
                });

            modelBuilder.Entity("ProfesionalProfile_District3_MVC.Models.User", b =>
                {
                    b.Navigation("AssessmentResult");

                    b.Navigation("Notifications");

                    b.Navigation("Privacy");

                    b.Navigation("Project");

                    b.Navigation("Volunteering");

                    b.Navigation("WorkExperience");
                });
#pragma warning restore 612, 618
        }
    }
}

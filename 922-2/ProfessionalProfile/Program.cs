
using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.DatabaseContext;
using ProfessionalProfile.Interfaces;
using ProfessionalProfile.repo;
using ProfessionalProfile.Repo;


namespace ProfessionalProfile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContextFactory<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });
            builder.Services.AddSingleton<IAnswerRepo, AnswerRepo>();
            builder.Services.AddSingleton<IAssessmentResultRepo, AssessmentResultRepo>();
            builder.Services.AddSingleton<IAssessmentTestRepo, AssessmentTestRepo>();
            builder.Services.AddSingleton<IBusinessCardRepo, BusinessCardRepo>();
            builder.Services.AddSingleton<ICertificateRepo, CertificateRepo>();
            builder.Services.AddSingleton<IEducationRepo, EducationRepo>();
            builder.Services.AddSingleton<IEndorsementRepo, EndorsementRepo>();
            builder.Services.AddSingleton<INotificationRepo, NotificationRepo>();
            builder.Services.AddSingleton<IPrivacyRepo, PrivacyRepo>();
            builder.Services.AddSingleton<IProjectRepo, ProjectRepo>();
            builder.Services.AddSingleton<IQuestionRepo, QuestionRepo>();
            builder.Services.AddSingleton<ISkillRepo, SkillRepo>();
            builder.Services.AddSingleton<IUserRepoInterface, UserRepo>();
            builder.Services.AddSingleton<IVolunteeringRepo, VolunteeringRepo>();
            builder.Services.AddSingleton<IWorkExperienceRepo, WorkExperienceRepo>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

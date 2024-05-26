using District3API.domain;
using District3API.Repos;
using Microsoft.EntityFrameworkCore;
using ProfessionalProfile.Interfaces;
using ProfessionalProfile.repo;
using ProfessionalProfile.Repo;
using Server.DatabaseContext;
//https://localhost:7097/api/Answer/GetAll
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContextFactory<ProfessionalProfile.DatabaseContext.DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddDbContextFactory<District3API.DataBaseContext.DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddDbContext<ProjectDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<District3API.RepoInterfaces.IRepoInterface<Account>, AccountRepository>();
builder.Services.AddScoped<District3API.RepoInterfaces.IRepoInterface<BlockedProfile>, BlockedProfileRepository>();
builder.Services.AddScoped<District3API.RepoInterfaces.IRepoInterface<CloseFriendProfile>, CloseFriendsProfileRepository>();
builder.Services.AddScoped<District3API.RepoInterfaces.IRepoInterface<FancierProfile>, FancierProfileRepository>();
// TODO: I do not understand why this below is not working
builder.Services.AddScoped<District3API.RepoInterfaces.IRepoInterface<Group>, GroupRepository>();
builder.Services.AddScoped<District3API.RepoInterfaces.IRepoInterface<Highlight>, HighlightRepository>();
builder.Services.AddScoped<District3API.RepoInterfaces.IRepoInterface<Post>, PostRepository>();
builder.Services.AddScoped<District3API.RepoInterfaces.IRepoInterface<AutisticUser>, UserRepository>();

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



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using ProfesionalProfile_District3_MVC.Data;
using ProfesionalProfile_District3_MVC.Interfaces;
using ProfesionalProfile_District3_MVC.Repositories;
using ProfesionalProfile_District3_MVC.Models;
using ProfesionalProfile_District3_MVC.UserThings;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddScoped<IAnswerRepo, AnswerRepo>();
builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
builder.Services.AddScoped<IAssessmentResultRepo, AssessmentResultRepo>();
builder.Services.AddScoped<IAssessmentTestRepo, AssessmentTestRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ISkillRepo, SkillRepo>();
builder.Services.AddScoped<IBusinessCardRepo, BusinessCardRepo>();
builder.Services.AddScoped<ICertificateRepo, CertificateRepo>();
builder.Services.AddScoped<IEducationRepo, EducationRepo>();
builder.Services.AddScoped<IEndorsementRepo, EndorsementRepo>();
builder.Services.AddScoped<INotificationRepo, NotificationRepo>();
builder.Services.AddScoped<IPrivacyRepo, PrivacyRepo>();
builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
builder.Services.AddScoped<IVolunteeringRepo, VolunteeringRepo>();
builder.Services.AddScoped<IWorkExperienceRepo, WorkExperienceRepo>();

// ============================================================================================================
builder.Services.AddScoped<IBlocksRepository, BlocksRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IControversialFeedRepository, ControversialFeedRepository>();
builder.Services.AddScoped<IFeedConfigurationRepository, FeedConfigurationRepository>();
builder.Services.AddScoped<IFollowsRepository, FollowsRepository>();
builder.Services.AddScoped<IFollowedFeedFollowedUsersRepository, FollowedFeedFollowedUsersRepository>();
builder.Services.AddScoped<IFollowSuggestionRepository, FollowSuggestionRepository>();
builder.Services.AddScoped<ILocationsRepository, LocationsRepository>();
builder.Services.AddScoped<IMediasRepository, MediasRepository>();
builder.Services.AddScoped<IPostArchivedRepository, PostArchivedRepository>();
builder.Services.AddScoped<IPostReportedRepository, PostReportedRepository>();
builder.Services.AddScoped<IPostSavedsRepository, PostSavedsRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<ITrendingFeedRepository, TrendingFeedRepository>();
builder.Services.AddScoped<IUsersRepositoryGAMBA, UsersRepositoryGAMBA>();
builder.Services.AddScoped<IFollowingFeedRepository, FollowingFeedRepository>();
builder.Services.AddScoped<IPostGAMBARepository, PostsGAMBARepository>();
builder.Services.AddScoped<IRepoInterface<Account>, AccountRepository>();
builder.Services.AddScoped<IRepoInterface<BlockedProfile>, BlockedProfileRepository>();
builder.Services.AddScoped<IRepoInterface<CloseFriendProfile>, CloseFriendsProfileRepository>();
builder.Services.AddScoped<IRepoInterface<Group>, GroupRepository>();
builder.Services.AddScoped<IRepoInterface<Highlight>, HighlightRepository>();
builder.Services.AddScoped<IRepoInterface<Post>, PostRepository>();
builder.Services.AddScoped<IRepoInterface<FancierProfile>, FancierProfileRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
       name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();

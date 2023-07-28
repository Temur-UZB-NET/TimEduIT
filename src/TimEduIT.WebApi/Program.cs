using TimEduIT.DataAccess.Interfaces.Categories;
using TimEduIT.DataAccess.Interfaces.Courses;
using TimEduIT.DataAccess.Interfaces.Users;
using TimEduIT.DataAccess.Interfaces.Videos;
using TimEduIT.DataAccess.Repositories.Categories;
using TimEduIT.DataAccess.Repositories.Courses;
using TimEduIT.DataAccess.Repositories.Users;
using TimEduIT.DataAccess.Repositories.Videos;
using TimEduIT.Service.Interfaces.Auth;
using TimEduIT.Service.Interfaces.Categories;
using TimEduIT.Service.Interfaces.Common;
using TimEduIT.Service.Interfaces.Courses;
using TimEduIT.Service.Interfaces.Notification;
using TimEduIT.Service.Interfaces.Videos;
using TimEduIT.Service.Service.Auth;
using TimEduIT.Service.Service.Categories;
using TimEduIT.Service.Service.Common;
using TimEduIT.Service.Service.Courses;
using TimEduIT.Service.Service.Notification;
using TimEduIT.Service.Service.Videos;
using TimEduIT.Service.Services.Auth;
using TimEduIT.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IVideoService, VideoService>();



builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>(); 

builder.Services.AddScoped<IUserRepository, UsersRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPoginator, Paginator>();
builder.Services.AddSingleton<ISmsSender, SmsSender>();

builder.Services.AddScoped<ICourseRepository,CoursesRepository>();
builder.Services.AddScoped<ICoursesService, CoursesCervice>();
builder.Services.AddScoped<IVideoProtsesService, VideoProtsesService>();
builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<IVideoRepository, VideosRepository>();


builder.ConfigureJwtAuth();
builder.ConfigureSwaggerAuth();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

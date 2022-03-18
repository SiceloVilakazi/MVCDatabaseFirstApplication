global using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WolfUniversity.Commands;
using WolfUniversity.Domain;
using WolfUniversity.Infrastructure;
using WolfUniversity.Queries;

var builder = WebApplication.CreateBuilder(args);


#region Get Handlers
//builder.Services.AddMediatR(typeof(GetStudentsQueryHandler).Assembly);
//builder.Services.AddMediatR(typeof(GetCoursesQueryHandler).Assembly);
//builder.Services.AddMediatR(typeof(GetCourseByIdQueryHandler).Assembly);
//builder.Services.AddMediatR(typeof(GetStudentByIdQueryHandler).Assembly);
//builder.Services.AddMediatR(typeof(AddCourseCommandHandler).Assembly);
//builder.Services.AddMediatR(typeof(AddStudentCommandHandler).Assembly);
//builder.Services.AddMediatR(typeof(EditCourseCommandHandler).Assembly);
//builder.Services.AddMediatR(typeof(RemoveCourseCommandHandler).Assembly);
//builder.Services.AddMediatR(typeof(EditStudentCommandHandler).Assembly);
//builder.Services.AddMediatR(typeof(RemoveStudentCommandHandler).Assembly);

var coursecommandAssembly = typeof(AddCourseCommand).GetTypeInfo().Assembly;
builder.Services.AddMediatR(coursecommandAssembly);

var commandAssembly = typeof(AddStudentCommand).GetTypeInfo().Assembly;
builder.Services.AddMediatR(commandAssembly);


var queryAssembly = typeof(GetCourseByIdQuery).GetTypeInfo().Assembly;
builder.Services.AddMediatR(queryAssembly);

#endregion

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

//Services
builder.Services.AddTransient<ICourseServiceInterface, CourseService>();
builder.Services.AddTransient<IStudentServiceInterface, StudentService>();
//builder.Services.AddTransient<IEnrollmentServiceInterface, EnrollmentService>();
//builder.Services.AddTransient<IGradeServiceInterface, GradeService>();

//Repositories
builder.Services.AddTransient<ICourseRepository, CourseRepository>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
//builder.Services.AddTransient<IGradeRepository, GradeRepository>();
//builder.Services.AddTransient<IEnrollmentRepository, EnrollmentRepository>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();



IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
builder.Services.AddDbContext<WolfUniversityDBContext>
    (options=>options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

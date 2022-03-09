using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WolfUniversity.Infrastructure;
using WolfUniversity.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(GetStudentsQueryHandler).Assembly);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

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

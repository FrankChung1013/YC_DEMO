using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using YCDemoMVC.DBModel;
using YCDemoMVC.Extentions;
using YCDemoMVC.Interfaces;
using YCDemoMVC.Repositories;
using YCDemoMVC.Services;

// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
builder.Host.UseNLog();

builder.Services.AddDbConnection(builder.Configuration);
// var connectionString = builder.Configuration.GetConnectionString("DBConnectionString");
// builder.Services.AddDbContext<YCDemoContext>(options =>
// {
//     options.UseSqlServer(connectionString, sqlServerOptionsAction:
//         sqlOptions =>
//         {
//             sqlOptions.EnableRetryOnFailure();
//         });
// });
// Add services to the container.
builder.Services.AddDiRegisterCollection();
// builder.Services.AddAutoMapper(typeof(Program).Assembly);
// builder.Services.AddScoped<IMemberRepository, MemberRepository>();
// builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddMvc();

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
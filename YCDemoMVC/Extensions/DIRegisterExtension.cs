using YCDemoMVC.Interfaces;
using YCDemoMVC.Repositories;
using YCDemoMVC.Services;

namespace YCDemoMVC.Extentions;

public static class DIRegisterExtension
{
    public static IServiceCollection AddDiRegisterCollection(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Program).Assembly);
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IMemberService, MemberService>();

        return services;
    }
}
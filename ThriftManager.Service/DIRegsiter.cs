using Microsoft.Extensions.DependencyInjection;
using ThriftManager.Service.ContributionServices;
using ThriftManager.Service.MemberServices;
using ThriftManager.Services;

namespace ThriftManager.Service;

public static class DIRegsiter
{
    public static IServiceCollection AddThriftServices(this IServiceCollection services)
    {
        services.AddInfrastructure();
        services.AddScoped<IMemberService, MemberService>();
        services.AddTransient<IGroupService, GroupServices>();
        services.AddTransient<IContributionService, ContributionService>();

        return services;
    }
}

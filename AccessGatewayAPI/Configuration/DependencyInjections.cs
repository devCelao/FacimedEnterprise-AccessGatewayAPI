using AccessGatewayApplication.Services;
using WebApiCore.Configuration;

namespace AccessGatewayAPI.Configuration;

public static class DependencyInjections
{
    public static void AddRegisterServices(this IServiceCollection Services, IConfiguration Configuration)
    {
        Services.AddHostsAPIConfiguration(Configuration);
        Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        Services.AddHttpClient<IAuthenticationService, AuthenticationService>();
        Services.AddHttpClient<IUserManagementService, UserManagementService>();
    }
}

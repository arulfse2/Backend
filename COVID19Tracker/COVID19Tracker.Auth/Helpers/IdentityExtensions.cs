using Microsoft.Extensions.DependencyInjection;

namespace COVID19Tracker.Auth
{
    public static class AppIdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddAppUserStore(this IIdentityServerBuilder builder)
        {
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.AddProfileService<AppProfileService>();
            builder.AddResourceOwnerValidator<AppResourceOwnerPasswordValidator>();

            return builder;
        }
    }
}

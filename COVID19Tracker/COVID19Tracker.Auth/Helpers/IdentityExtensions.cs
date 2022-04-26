using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using COVID19Tracker.Core.Query;
using COVID19Tracker.Core.Services;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace COVID19Tracker.Auth
{
    public static class AppIdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddAppUserStore(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddSingleton<IIdentityService, IdentityService>();

            builder.Services.AddTransient<IRequestHandler<GetUserByEmailAndPasswordQuery, User>, GetUserByEmailAndPasswordQueryHandler>();
            builder.Services.AddTransient<IRequestHandler<GetUserByEmailQuery, User>, GetUserByEmailQueryHandler>();
            builder.Services.AddTransient<IRequestHandler<GetUserByIdQuery, User>, GetUserByIdQueryHandler>();
            builder.Services.AddTransient<IRequestHandler<GetRoleByIdQuery, Role>, GetRoleByIdQueryHandler>();
            builder.Services.AddTransient<IRequestHandler<GetUserRolesByUserIdQuery, IEnumerable<UserRole>>, GetUserRolesByUserIdQueryHandler>();

            builder.AddResourceOwnerValidator<AppResourceOwnerPasswordValidator>();
            builder.Services.AddTransient<IResourceOwnerPasswordValidator, AppResourceOwnerPasswordValidator>();
            builder.AddProfileService<AppProfileService>();
            builder.Services.AddTransient<IProfileService, AppProfileService>();
            //builder.AddProfileService<ProfileService>();
            //builder.Services.AddTransient<IProfileService, ProfileService>();

            return builder;
        }
    }
}

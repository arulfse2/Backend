using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using IdentityModel;

namespace COVID19Tracker.Auth
{
    public class AppProfileService : IProfileService
    {
        protected readonly ILogger Logger;


        protected readonly IIdentityService _identityService;

        public AppProfileService(IIdentityService identityService, ILogger<AppProfileService> logger)
        {
            _identityService = identityService;
            Logger = logger;
        }


        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            Logger.LogDebug("Get profile called for subject {subject} from client {client} with claim types {claimTypes} via {caller}",
                context.Subject.GetSubjectId(),
                context.Client.ClientName ?? context.Client.ClientId,
                context.RequestedClaimTypes,
                context.Caller);

            var user = await _identityService.FindBySubjectId(context.Subject.GetSubjectId());
            var claims = new List<Claim>();
            if (user != null)
            {
                claims.Add(new Claim(JwtClaimTypes.Subject, user.SubjectId));
                claims.Add(new Claim("username", user.Email));
                claims.Add(new Claim("email", user.Email));
                var userRoles = await _identityService.FindUserRolesByUserId(context.Subject.GetSubjectId());
                if (userRoles != null && userRoles.Count() > 0)
                {
                    userRoles.ToList().ForEach(async x =>
                    {
                        var role = await _identityService.FindRoleById(x.RoleId);
                        if (role != null)
                            claims.Add(new Claim("role",role.Name.ToLower()));
                    });
                }
            }

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _identityService.FindBySubjectId(context.Subject.GetSubjectId());
            context.IsActive = user != null && user.IsActive;
        }
    }
}

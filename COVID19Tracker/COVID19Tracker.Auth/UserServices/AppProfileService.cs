using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace COVID19Tracker.Auth
{
    public class AppProfileService : IProfileService
    {
        protected readonly ILogger Logger;


        protected readonly IAuthRepository _userRepository;

        public AppProfileService(IAuthRepository userRepository, ILogger<AppProfileService> logger)
        {
            _userRepository = userRepository;
            Logger = logger;
        }


        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();

            Logger.LogDebug("Get profile called for subject {subject} from client {client} with claim types {claimTypes} via {caller}",
                context.Subject.GetSubjectId(),
                context.Client.ClientName ?? context.Client.ClientId,
                context.RequestedClaimTypes,
                context.Caller);

            var user = await _userRepository.FindBySubjectId(context.Subject.GetSubjectId());

            var claims = new List<Claim>
            {
                new Claim("role", "admin"),
                new Claim("role", "user"),
                new Claim("username", user.UserName),
                new Claim("email", user.Email)
            };

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userRepository.FindBySubjectId(context.Subject.GetSubjectId());
            context.IsActive = user != null;
        }
    }
}

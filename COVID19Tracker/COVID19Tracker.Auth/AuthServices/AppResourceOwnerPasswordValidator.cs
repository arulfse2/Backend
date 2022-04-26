using IdentityServer4.Validation;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using IdentityServer4.Models;
using System;

namespace COVID19Tracker.Auth
{
    public class AppResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        protected readonly IIdentityService _identityService;

        public AppResourceOwnerPasswordValidator(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public virtual async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var user = await _identityService.FindByEmail(context.UserName);
                if (user != null)
                {
                    var res = await _identityService.ValidateCredentials(context.UserName, context.Password);
                    if (res)
                    {
                        var claims = new List<Claim>();
                        claims.Add(new Claim("username", user.Email));
                        claims.Add(new Claim("email", user.Email));
                        var userRoles = await _identityService.FindUserRolesByUserId(user.SubjectId);
                        if (userRoles != null && userRoles.Count() > 0)
                        {
                            userRoles.ToList().ForEach(async x =>
                            {
                                var role = await _identityService.FindRoleById(x.RoleId);
                                if (role != null)
                                    claims.Add(new Claim("role", role.Name.ToLower()));
                            });
                        }
                        context.Result = new GrantValidationResult(subject: user.SubjectId, authenticationMethod: GrantType.ResourceOwnerPassword, claims: claims);
                        return;
                    }
                    else
                    {
                        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Incorrect password");
                        return;
                    }
                }
                else
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "User does not exist.");
                    return;
                }
            }
            catch (Exception ex)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or password");
                Console.WriteLine(ex);
            }
            return;
        }
    }
}

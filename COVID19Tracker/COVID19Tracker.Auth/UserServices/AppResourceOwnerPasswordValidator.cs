using IdentityServer4.Validation;
using IdentityModel;
using System.Threading.Tasks;

namespace COVID19Tracker.Auth
{
    public class AppResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IAuthRepository _userRepository;

        public AppResourceOwnerPasswordValidator(IAuthRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var res = Task.Run(() => _userRepository.ValidateCredentials(context.UserName, context.Password)).Result;
            if (res)
            {
                var user = Task.Run(() => _userRepository.FindByEmail(context.UserName)).Result;
                context.Result = new GrantValidationResult(user.SubjectId, OidcConstants.AuthenticationMethods.Password);
            }

            return Task.FromResult(0);
        }
    }
}

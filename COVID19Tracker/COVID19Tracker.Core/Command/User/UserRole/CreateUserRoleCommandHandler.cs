using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, UserRole>
    {
        private readonly IUserService _userService;

        public CreateUserRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<UserRole> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            return await _userService.AddUserRole(request.UserRole);
        }
    }
}

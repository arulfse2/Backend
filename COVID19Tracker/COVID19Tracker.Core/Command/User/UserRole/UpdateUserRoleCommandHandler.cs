using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, bool>
    {
        private readonly IUserService _userService;

        public UpdateUserRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateUserRole(request.UserRole, request.Id);
        }
    }
}

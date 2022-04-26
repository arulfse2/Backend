using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand, bool>
    {
        private readonly IUserService _userService;

        public DeleteUserRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            return await _userService.DeleteUserRole(request.Id);
        }
    }
}

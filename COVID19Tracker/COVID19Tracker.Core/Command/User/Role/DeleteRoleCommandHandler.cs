using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, bool>
    {
        private readonly IUserService _userService;

        public DeleteRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            return await _userService.DeleteRole(request.Id);
        }
    }
}

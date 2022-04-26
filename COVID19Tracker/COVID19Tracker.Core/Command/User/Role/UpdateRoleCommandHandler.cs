using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, bool>
    {
        private readonly IUserService _userService;

        public UpdateRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateRole(request.Role, request.Id);
        }
    }
}

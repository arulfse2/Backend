using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Role>
    {
        private readonly IUserService _userService;

        public CreateRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<Role> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _userService.AddRole(request.Role);
        }
    }
}

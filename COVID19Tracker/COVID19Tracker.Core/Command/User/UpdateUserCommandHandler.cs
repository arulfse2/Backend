using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateUser(request.User, request.Id);
        }
    }
}

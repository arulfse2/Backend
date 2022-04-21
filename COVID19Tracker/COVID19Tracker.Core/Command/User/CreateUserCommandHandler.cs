using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.AddUser(request.User);
        }
    }
}

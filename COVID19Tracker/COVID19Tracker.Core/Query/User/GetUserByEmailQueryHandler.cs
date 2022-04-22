using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        private readonly IUserService _userService;

        public GetUserByEmailQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByEmail(request.Email);
        }
    }
}

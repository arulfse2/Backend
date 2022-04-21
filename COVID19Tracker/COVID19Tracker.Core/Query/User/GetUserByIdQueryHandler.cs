using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserService _userService;

        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserById(request.Id);
        }
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly IUserService _userService;

        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAllUsers();
        }
    }
}

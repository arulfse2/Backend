using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUserRolesByUserIdQueryHandler : IRequestHandler<GetUserRolesByUserIdQuery, IEnumerable<UserRole>>
    {
        private readonly IUserService _userService;

        public GetUserRolesByUserIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<UserRole>> Handle(GetUserRolesByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserRolesByUserId(request.UserId);
        }
    }
}

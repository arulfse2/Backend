using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, IEnumerable<UserRole>>
    {
        private readonly IUserService _userService;

        public GetUserRolesQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IEnumerable<UserRole>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAllUserRoles();
        }
    }
}

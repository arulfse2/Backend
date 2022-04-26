using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, IEnumerable<Role>>
    {
        private readonly IUserService _userService;

        public GetRolesQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IEnumerable<Role>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAllRoles();
        }
    }
}

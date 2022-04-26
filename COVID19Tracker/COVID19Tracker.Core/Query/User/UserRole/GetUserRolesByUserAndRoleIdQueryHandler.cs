using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUserRolesByUserAndRoleIdQueryHandler : IRequestHandler<GetUserRolesByUserAndRoleIdQuery, UserRole>
    {
        private readonly IUserService _userService;

        public GetUserRolesByUserAndRoleIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserRole> Handle(GetUserRolesByUserAndRoleIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserRoleByUserAndRoleId(request.UserId, request.RoleId);
        }
    }
}

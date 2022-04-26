using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUserRoleByIdQueryHandler : IRequestHandler<GetUserRoleByIdQuery, UserRole>
    {
        private readonly IUserService _userService;

        public GetUserRoleByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserRole> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserRoleById(request.Id);
        }
    }
}

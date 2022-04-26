using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Role>
    {
        private readonly IUserService _userService;

        public GetRoleByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Role> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetRoleById(request.Id);
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUserByEmailAndPasswordQueryHandler : IRequestHandler<GetUserByEmailAndPasswordQuery, bool>
    {
        private readonly IUserService _userService;

        public GetUserByEmailAndPasswordQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(GetUserByEmailAndPasswordQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByEmailAndPassword(request.Email, request.Password);
        }
    }
}

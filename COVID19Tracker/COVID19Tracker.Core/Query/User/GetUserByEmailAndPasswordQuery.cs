using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUserByEmailAndPasswordQuery : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

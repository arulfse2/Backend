using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUserByEmailQuery : IRequest<User>
    {
        public string Email { get; set; }
    }
}

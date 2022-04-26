using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUserRoleByIdQuery : IRequest<UserRole>
    {
        public string Id { get; set; }
    }
}

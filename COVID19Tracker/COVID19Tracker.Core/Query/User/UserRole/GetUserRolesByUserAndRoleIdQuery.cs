using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUserRolesByUserAndRoleIdQuery : IRequest<UserRole>
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}

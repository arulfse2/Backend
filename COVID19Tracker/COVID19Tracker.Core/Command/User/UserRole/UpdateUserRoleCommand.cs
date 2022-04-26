using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class UpdateUserRoleCommand : IRequest<bool>
    {
        public UserRole UserRole { get; set; }
        public string Id { get; set; }
    }
}

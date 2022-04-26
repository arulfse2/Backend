using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class CreateRoleCommand : IRequest<Role>
    {
        public Role Role { get; set; }
    }
}

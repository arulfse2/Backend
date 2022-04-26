using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class UpdateRoleCommand : IRequest<bool>
    {
        public Role Role { get; set; }
        public string Id { get; set; }
    }
}

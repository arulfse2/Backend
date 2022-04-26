using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class CreateUserRoleCommand : IRequest<UserRole>
    {
        public UserRole UserRole { get; set; }
    }
}

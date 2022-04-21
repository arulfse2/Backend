using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class CreateUserCommand : IRequest<User>
    {
        public User User { get; set; }
    }
}

using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public User User { get; set; }
        public string Id { get; set; }
    }
}

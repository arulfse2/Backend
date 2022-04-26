using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}

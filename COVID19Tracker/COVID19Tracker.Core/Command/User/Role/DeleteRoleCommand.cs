using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class DeleteRoleCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}

using MediatR;

namespace COVID19Tracker.Core.Command
{
    public class DeleteUserRoleCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}

using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetRoleByIdQuery : IRequest<Role>
    {
        public string Id { get; set; }
    }
}

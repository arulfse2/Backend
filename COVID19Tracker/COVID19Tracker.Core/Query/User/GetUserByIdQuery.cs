using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public string Id { get; set; }
    }
}

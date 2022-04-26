using System.Collections.Generic;
using COVID19Tracker.Core.Entities;
using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUserRolesByUserIdQuery : IRequest<IEnumerable<UserRole>>
    {
        public string UserId { get; set; }
    }
}

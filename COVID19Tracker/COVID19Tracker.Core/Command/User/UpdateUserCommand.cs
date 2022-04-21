using COVID19Tracker.Core.Entities;
using MediatR;
using System;

namespace COVID19Tracker.Core.Command
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public User User { get; set; }
        public Guid Id { get; set; }
    }
}

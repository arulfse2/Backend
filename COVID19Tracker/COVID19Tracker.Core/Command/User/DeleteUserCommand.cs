using MediatR;
using System;

namespace COVID19Tracker.Core.Command
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

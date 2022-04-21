using MediatR;

namespace COVID19Tracker.Core.Query
{
    public class GetUserByEmailAndPasswordQuery : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

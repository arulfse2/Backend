using System;
using System.Threading.Tasks;
using MediatR;
using COVID19Tracker.Core.Query;
using AutoMapper;

namespace COVID19Tracker.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthRepository(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<bool> ValidateCredentials(string email, string password)
        {
            var user = await FindByEmail(email);
            if (user != null)
            {
                return user.Password.Equals(password);
            }

            return false;
        }

        public async Task<AppUser> FindBySubjectId(string subjectId)
        {
            Guid id = Guid.Parse(subjectId);;
            var res = await _mediator.Send(new GetUserByIdQuery { Id = id });
            var user = _mapper.Map<AppUser>(res);
            return user;
        }

        public async Task<AppUser> FindByEmail(string email)
        {
            var res = await _mediator.Send(new GetUserByEmailQuery { Email = email });
            var user = _mapper.Map<AppUser>(res);
            return user;
        }
    }
}

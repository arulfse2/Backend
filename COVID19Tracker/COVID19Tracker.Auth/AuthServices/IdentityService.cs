using System.Threading.Tasks;
using MediatR;
using COVID19Tracker.Core.Query;
using AutoMapper;
using System.Collections.Generic;

namespace COVID19Tracker.Auth
{
    public class IdentityService : IIdentityService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public IdentityService(IMapper mapper, IMediator mediator)
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
            var res = await _mediator.Send(new GetUserByIdQuery { Id = subjectId });
            var user = _mapper.Map<AppUser>(res);
            return user;
        }

        public async Task<AppUser> FindByEmail(string email)
        {
            var res = await _mediator.Send(new GetUserByEmailQuery { Email = email });
            var user = _mapper.Map<AppUser>(res);
            return user;
        }

        public async Task<IEnumerable<AppUserRole>> FindUserRolesByUserId(string subjectId)
        {
            var res = await _mediator.Send(new GetUserRolesByUserIdQuery { UserId = subjectId });
            var userRoles = _mapper.Map<IEnumerable<AppUserRole>>(res);
            return userRoles;
        }

        public async Task<AppRole> FindRoleById(string roleId)
        {
            var res = await _mediator.Send(new GetRoleByIdQuery { Id = roleId });
            var role = _mapper.Map<AppRole>(res);
            return role;
        }
    }
}

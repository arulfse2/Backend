using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COVID19Tracker.Auth
{
    public interface IIdentityService
    {
        Task<bool> ValidateCredentials(string username, string password);
        Task<AppUser> FindBySubjectId(string subjectId);
        Task<AppUser> FindByEmail(string email);
        Task<IEnumerable<AppUserRole>> FindUserRolesByUserId(string subjectId);
        Task<AppRole> FindRoleById(string roleId);
    }
}

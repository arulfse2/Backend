using COVID19Tracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COVID19Tracker.Core.Contracts
{
    public interface IAuthService
    {
        Task<bool> Register(User user);
        Task<bool> Login(string userName, string password);
        Task<IEnumerable<Role>> GetUserRoles(Guid userId);
    }
}

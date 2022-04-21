using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace COVID19Tracker.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly List<AppUser> _users = new List<AppUser>
        {
            new AppUser{
               SubjectId = Guid.NewGuid().ToString().ToUpper(),
               UserName = "fse3admin",
               Password = "pass@word1",
               Email = "arulprakash.s@cognizant.com"
            }
        };

        public bool ValidateCredentials(string username, string password)
        {
            var user = FindByUsername(username);
            if (user != null)
            {
                return user.Password.Equals(password);
            }

            return false;
        }

        public Task<AppUser> FindBySubjectId(string subjectId)
        {
            var list = _users.FirstOrDefault(x => x.SubjectId == subjectId);
            return Task.FromResult(list);
        }

        public AppUser FindByUsername(string username)
        {
            return _users.FirstOrDefault(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}

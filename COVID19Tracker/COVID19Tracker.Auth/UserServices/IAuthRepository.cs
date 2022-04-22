using System.Threading.Tasks;

namespace COVID19Tracker.Auth
{
    public interface IAuthRepository
    {
        Task<bool> ValidateCredentials(string username, string password);

        Task<AppUser> FindBySubjectId(string subjectId);

        Task<AppUser> FindByEmail(string email);
    }
}

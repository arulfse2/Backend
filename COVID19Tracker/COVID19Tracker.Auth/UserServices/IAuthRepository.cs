using System.Threading.Tasks;

namespace COVID19Tracker.Auth
{
    public interface IAuthRepository
    {
        bool ValidateCredentials(string username, string password);

        Task<AppUser> FindBySubjectId(string subjectId);

        AppUser FindByUsername(string username);
    }
}

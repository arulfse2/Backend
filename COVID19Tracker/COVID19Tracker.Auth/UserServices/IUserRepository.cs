using System.Threading.Tasks;

namespace COVID19Tracker.Auth
{
    public interface IUserRepository
    {
        bool ValidateCredentials(string username, string password);

        Task<AppUser> FindBySubjectId(string subjectId);

        AppUser FindByUsername(string username);
    }
}

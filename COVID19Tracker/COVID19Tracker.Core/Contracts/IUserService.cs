using COVID19Tracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COVID19Tracker.Core.Contracts
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<bool> UpdateUser(User input, Guid userId);
        Task<bool> DeleteUser(Guid userId);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(Guid userId);
        Task<User> GetUserByEmailAndPassword(string email, string password);
        Task<User> GetUserByEmail(string email);
    }
}

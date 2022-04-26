using COVID19Tracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COVID19Tracker.Core.Contracts
{
    public interface IUserService
    {
        #region User
        Task<User> AddUser(User user);
        Task<bool> UpdateUser(User input, string userId);
        Task<bool> DeleteUser(string userId);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(string userId);
        Task<User> GetUserByEmailAndPassword(string email, string password);
        Task<User> GetUserByEmail(string email);
        #endregion User

        #region Role
        Task<Role> AddRole(Role role);
        Task<bool> UpdateRole(Role input, string roleId);
        Task<bool> DeleteRole(string roleId);
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> GetRoleById(string roleId);
        #endregion Role

        #region UserRole
        Task<UserRole> AddUserRole(UserRole userRole);
        Task<bool> UpdateUserRole(UserRole input, string userRoleId);
        Task<bool> DeleteUserRole(string userRoleId);
        Task<IEnumerable<UserRole>> GetAllUserRoles();
        Task<UserRole> GetUserRoleById(string userRoleId);
        Task<IEnumerable<UserRole>> GetUserRolesByUserId(string userId);
        Task<UserRole> GetUserRoleByUserAndRoleId(string userId, string roleId);
        #endregion UserRole
    }
}

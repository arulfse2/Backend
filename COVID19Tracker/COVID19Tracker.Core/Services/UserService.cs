using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COVID19Tracker.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;
        private readonly IMongoCollection<Role> _roles;
        private readonly IMongoCollection<UserRole> _userRoles;
        private readonly IMongoClient _client;
        private readonly UserConfig _userConfig;
        public UserService(IOptionsMonitor<UserConfig> userConfig)
        {
            _userConfig = userConfig.CurrentValue;
            _client = new MongoClient(_userConfig.ConnectionString);
            var database = _client.GetDatabase(_userConfig.DatabaseName);

            _users = database.GetCollection<User>(_userConfig.CollectionNames.UserCollectioName);
            _roles = database.GetCollection<Role>(_userConfig.CollectionNames.RoleCollectioName);
            _userRoles = database.GetCollection<UserRole>(_userConfig.CollectionNames.UserRoleCollectioName);
        }

        public async Task<Role> AddRole(Role role)
        {
            Role rl = new Role();
            try
            {
                await _roles.InsertOneAsync(role);
                var filter = Builders<Role>.Filter.Where(x => x.RoleId.ToLower().Contains(role.RoleId.ToLower()));
                rl = await _roles.Find(filter).FirstOrDefaultAsync();
            }
            catch (MongoException)
            {
                throw new Exception("Adding role failed");
            }
            return rl;
        }

        public async Task<UserRole> AddUserRole(UserRole userRole)
        {
            UserRole usrRole = new UserRole();
            try
            {
                await _userRoles.InsertOneAsync(userRole);
                var filter = Builders<UserRole>.Filter.Where(x => x.UserRoleId.ToLower().Contains(userRole.UserRoleId.ToLower()));
                usrRole = await _userRoles.Find(filter).FirstOrDefaultAsync();
            }
            catch (MongoException)
            {
                throw new Exception("Adding user role failed");
            }
            return usrRole;
        }

        public async Task<User> AddUser(User user)
        {
            User usr = new User();
            try
            {
                await _users.InsertOneAsync(usr);
                var filter = Builders<User>.Filter.Where(x => x.UserId.ToLower().Contains(user.UserId.ToLower()));
                usr = await _users.Find(filter).FirstOrDefaultAsync();
            }
            catch (MongoException)
            {
                throw new Exception("Adding user failed");
            }
            return usr;
        }

        public async Task<bool> DeleteRole(string roleId)
        {
            DeleteResult res = null;

            try
            {
                var filter = Builders<Role>.Filter.Where(x => x.RoleId.ToLower().Contains(roleId.ToLower()));
                res = await _roles.DeleteOneAsync(filter);
            }
            catch (MongoException)
            {
                throw new Exception("No document found");
            }
            return (res.IsAcknowledged && res.DeletedCount > 0) ? true : false;
        }

        public async Task<bool> DeleteUser(string userId)
        {
            DeleteResult res = null;

            try
            {
                var filter = Builders<User>.Filter.Where(x => x.UserId.ToLower().Contains(userId.ToLower()));
                res = await _users.DeleteOneAsync(filter);
            }
            catch (MongoException)
            {
                throw new Exception("No document found");
            }
            return (res.IsAcknowledged && res.DeletedCount > 0) ? true : false;
        }

        public async Task<bool> DeleteUserRole(string userRoleId)
        {
            DeleteResult res = null;

            try
            {
                var filter = Builders<UserRole>.Filter.Where(x => x.UserRoleId.ToLower().Contains(userRoleId.ToLower()));
                res = await _userRoles.DeleteOneAsync(filter);
            }
            catch (MongoException)
            {
                throw new Exception("No document found");
            }
            return (res.IsAcknowledged && res.DeletedCount > 0) ? true : false;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _roles.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<IEnumerable<UserRole>> GetAllUserRoles()
        {
            return await _userRoles.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _users.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Role> GetRoleById(string roleId)
        {
            Role rl = new Role();
            try
            {
                var filter = Builders<Role>.Filter.Where(x => x.RoleId.ToLower().Contains(roleId.ToLower()));
                rl = await _roles.Find(filter).FirstOrDefaultAsync();
            }
            catch (MongoException)
            {
                throw new Exception("Get role failed");
            }
            return rl;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User usr = new User();
            try
            {
                var filter = Builders<User>.Filter.Where(x => x.Email.ToLower().Contains(email.ToLower()));
                usr = await _users.Find(filter).FirstOrDefaultAsync();
            }
            catch (MongoException)
            {
                throw new Exception("Get user failed");
            }
            return usr;
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            User usr = new User();
            try
            {
                var filter = Builders<User>.Filter.Where(x => x.Email.ToLower().Contains(email.ToLower()) && x.Password.ToLower().Contains(password.ToLower()));
                usr = await _users.Find(filter).FirstOrDefaultAsync();
            }
            catch (MongoException)
            {
                throw new Exception("Get user failed");
            }
            return usr;
        }

        public async Task<User> GetUserById(string userId)
        {
            User usr = new User();
            try
            {
                var filter = Builders<User>.Filter.Where(x => x.UserId.ToLower().Contains(userId.ToLower()));
                usr = await _users.Find(filter).FirstOrDefaultAsync();
            }
            catch (MongoException)
            {
                throw new Exception("Get user failed");
            }
            return usr;
        }

        public async Task<UserRole> GetUserRoleById(string userRoleId)
        {
            UserRole usrRole = new UserRole();
            try
            {
                var filter = Builders<UserRole>.Filter.Where(x => x.UserRoleId.ToLower().Contains(userRoleId.ToLower()));
                usrRole = await _userRoles.Find(filter).FirstOrDefaultAsync();
            }
            catch (MongoException)
            {
                throw new Exception("Get user role failed");
            }
            return usrRole;
        }

        public async Task<UserRole> GetUserRoleByUserAndRoleId(string userId, string roleId)
        {
            UserRole usrRole = new UserRole();
            try
            {
                var filter = Builders<UserRole>.Filter.Where(x => x.UserId.ToLower().Contains(userId.ToLower()) && x.RoleId.ToLower().Contains(roleId.ToLower()));
                usrRole = await _userRoles.Find(filter).FirstOrDefaultAsync();
            }
            catch (MongoException)
            {
                throw new Exception("Get user role failed");
            }
            return usrRole;
        }

        public async Task<IEnumerable<UserRole>> GetUserRolesByUserId(string userId)
        {
            List<UserRole> usrRole = new List<UserRole>();
            try
            {
                var filter = Builders<UserRole>.Filter.Where(x => x.UserId.ToLower().Contains(userId.ToLower()));
                usrRole = await _userRoles.Find(filter).ToListAsync();
            }
            catch (MongoException)
            {
                throw new Exception("Get user roles failed");
            }
            return usrRole;
        }

        public async Task<bool> UpdateRole(Role input, string roleId)
        {
            Role role = new Role();
            UpdateResult res = null;
            try
            {
                var filter = Builders<Role>.Filter.Where(x => x.RoleId.ToLower().Contains(roleId.ToLower()));
                role = await _roles.Find(filter).FirstOrDefaultAsync();
                if (role != null)
                {
                    var update = Builders<Role>.Update
                        .Set(x => x.Name, input.Name)
                        .Set(x => x.IsActive, input.IsActive)
                        .Set(x => x.CreatedBy, role.CreatedBy)
                        .Set(x => x.CreatedDate, role.CreatedDate)
                        .Set(x => x.ModifiedBy, input.ModifiedBy)
                        .Set(x => x.ModifiedDate, input.ModifiedDate);
                    res = await _roles.UpdateOneAsync(filter, update);
                }
            }
            catch (MongoException)
            {
                throw new Exception("Update role failed");
            }
            return (res.IsAcknowledged && res.IsModifiedCountAvailable && res.ModifiedCount > 0) ? true : false;
        }

        public async Task<bool> UpdateUser(User input, string userId)
        {
            User usr = new User();
            UpdateResult res = null;
            try
            {
                var filter = Builders<User>.Filter.Where(x => x.UserId.ToLower().Contains(userId.ToLower()));
                usr = await _users.Find(filter).FirstOrDefaultAsync();
                if (usr != null)
                {
                    var update = Builders<User>.Update
                        .Set(x => x.FirstName, input.FirstName)
                        .Set(x => x.LastName, input.LastName)
                        .Set(x => x.Email, input.Email)
                        .Set(x => x.Phone, input.Phone)
                        .Set(x => x.Password, input.Password)
                        .Set(x => x.IsActive, input.IsActive)
                        .Set(x => x.CreatedBy, usr.CreatedBy)
                        .Set(x => x.CreatedDate, usr.CreatedDate)
                        .Set(x => x.ModifiedBy, input.ModifiedBy)
                        .Set(x => x.ModifiedDate, input.ModifiedDate);
                    res = await _users.UpdateOneAsync(filter, update);
                }
            }
            catch (MongoException)
            {
                throw new Exception("Update user failed");
            }
            return (res.IsAcknowledged && res.IsModifiedCountAvailable && res.ModifiedCount > 0) ? true : false;
        }

        public async Task<bool> UpdateUserRole(UserRole input, string userRoleId)
        {
            UserRole userRole = new UserRole();
            UpdateResult res = null;
            try
            {
                var filter = Builders<UserRole>.Filter.Where(x => x.UserRoleId.ToLower().Contains(userRoleId.ToLower()));
                userRole = await _userRoles.Find(filter).FirstOrDefaultAsync();
                if (userRole != null)
                {
                    var update = Builders<UserRole>.Update
                        .Set(x => x.IsActive, input.IsActive)
                        .Set(x => x.CreatedBy, userRole.CreatedBy)
                        .Set(x => x.CreatedDate, userRole.CreatedDate)
                        .Set(x => x.ModifiedBy, input.ModifiedBy)
                        .Set(x => x.ModifiedDate, input.ModifiedDate);
                    res = await _userRoles.UpdateOneAsync(filter, update);
                }
            }
            catch (MongoException)
            {
                throw new Exception("Update user role failed");
            }
            return (res.IsAcknowledged && res.IsModifiedCountAvailable && res.ModifiedCount > 0) ? true : false;
        }
    }
}

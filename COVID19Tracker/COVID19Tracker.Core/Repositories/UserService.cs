using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COVID19Tracker.Core.Repositories
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;
        private readonly IMongoClient _client;
        public UserService(IDatabaseSettings databaseSettings)
        {
            _client = new MongoClient(databaseSettings.UserConfig.ConnectionString);
            var database = _client.GetDatabase(databaseSettings.UserConfig.DatabaseName);

            _users = database.GetCollection<User>(databaseSettings.UserConfig.CollectionNames.UserCollectioName);
        }
        public async Task<User> AddUser(User user)
        {
            User usr = new User();
            try
            {
                await _users.InsertOneAsync(usr);
                usr = await _users.FindAsync(x => x.Id == user.Id).Result.FirstOrDefaultAsync();
            }
            catch (MongoException)
            {
                throw new Exception("Adding user failed");
            }
            return usr;
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            DeleteResult res = null;

            try
            {
                res = await _users.DeleteOneAsync(usr => usr.Id == userId);
            }
            catch (MongoException)
            {
                throw new Exception("No document found");
            }
            return (res.IsAcknowledged && res.DeletedCount > 0) ? true : false;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _users.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<bool> GetUserByEmailAndPassword(string email, string password)
        {
            User usr = new User();
            try
            {
                usr = await _users.FindAsync(x => x.Email.ToLower() == email.ToLower() && x.Password.ToLower() == password.ToLower()).Result.FirstOrDefaultAsync();
            }
            catch (MongoException)
            {
                throw new Exception("Get user failed");
            }
            return usr != null ? true : false;
        }

        public async Task<User> GetUserById(Guid userId)
        {
            User usr = new User();
            try
            {
                usr = await _users.FindAsync(x => x.Id == userId).Result.FirstOrDefaultAsync();
            }
            catch (MongoException)
            {
                throw new Exception("Get user failed");
            }
            return usr;
        }

        public async Task<bool> UpdateUser(User input, Guid userId)
        {
            User usr = new User();
            UpdateResult res = null;
            try
            {
                usr = await _users.FindAsync(x => x.Id == userId).Result.FirstOrDefaultAsync();
                if (usr != null)
                {
                    var filter = Builders<User>.Filter.Eq(x => x.Id, userId);
                    var update = Builders<User>.Update
                        .Set(x => x.FirstName, input.FirstName)
                        .Set(x => x.LastName, input.LastName)
                        .Set(x => x.Email, input.Email)
                        .Set(x => x.Phone, input.Phone)
                        .Set(x => x.Password, input.Password)
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
    }
}

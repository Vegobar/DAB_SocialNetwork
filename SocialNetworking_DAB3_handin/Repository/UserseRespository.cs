using SocialNetworking_DAB3_handin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocialNetworking_DAB3_handin.Data;
using BCrypt;
using SocialNetworking_DAB3_handin.ViewModels;

namespace SocialNetworking_DAB3_handin.Repository
{
    public class UserseRespository : IUsersRepository
    {
        MongoDbContext db = new MongoDbContext();

        public async Task Add(Users users)
        {
           try
            {
                var hashedPw = BCrypt.Net.BCrypt.HashPassword(users.Password);
                users.Password = hashedPw;

                await db.Users.InsertOneAsync(users);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Users> GetUserByName(User_Login users)
        {
            try
            {
                FilterDefinition<Users> filter = Builders<Users>.Filter.Eq("Username", users.Username);
                return await db.Users.Find(filter).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }

        }

        public async Task Delete(string id)
        {
            try
            {
                FilterDefinition<Users> data = Builders<Users>.Filter.Eq("Id", id);
                await db.Users.DeleteOneAsync(data);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Users> GetUsers(string id)
        {
            try
            {
                FilterDefinition<Users> filter = Builders<Users>.Filter.Eq("Id", id);
                return await db.Users.Find(filter).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            try
            {
                return await db.Users.Find(_ => true).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(Users users)
        {
            try
            {
                await db.Users.ReplaceOneAsync(filter: g => g.Id == users.Id, replacement: users);
            }
            catch
            {
                throw;
            }
        }
    }
}

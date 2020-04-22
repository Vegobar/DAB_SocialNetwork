using MongoDB.Driver;
using SocialNetworking_DAB3_handin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworking_DAB3_handin.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase database;
        public MongoDbContext()
        {
            var client = new MongoClient("mongodb+srv://Vegobar:Vegobarerdejlig1@socalnetwork01-crko6.mongodb.net/test?retryWrites=true&w=majority");
            database = client.GetDatabase("SocialNetwork");
        }

        public IMongoCollection<Users> Users
        {
            get 
            { 
                return database.GetCollection<Users>("Users"); 
            }
        }
    }
}

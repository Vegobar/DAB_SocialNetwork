using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworking_DAB3_handin.Models
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        [BsonRequired]
        public string Password { get; set; }

        [BsonRequired]
        public string Username { get; set; }

        [BsonRequired]
        public string Email { get; set; }

        [BsonRequired]
        public string Gender { get; set; }

        [BsonRequired]
        public int Age { get; set; }


        public string FollowId { get; set; }
        public string CurrentFollowers { get; set; }

    }
}

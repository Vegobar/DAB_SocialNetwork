using SocialNetworking_DAB3_handin.Models;
using SocialNetworking_DAB3_handin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworking_DAB3_handin.Repository
{
    public interface IUsersRepository
    {
        Task Add(Users users);
        Task Update(Users users);
        Task Delete(string id);
        Task<Users> GetUsers(string id);
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUserByName(User_Login users);
    }
}

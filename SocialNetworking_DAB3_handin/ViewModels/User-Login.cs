using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworking_DAB3_handin.ViewModels
{
    public class User_Login
    {
        [Required, MaxLength(254)]
        public string Username { get; set; }

        [Required, MaxLength(56)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsLoggedIn { get; set; }
    }
}

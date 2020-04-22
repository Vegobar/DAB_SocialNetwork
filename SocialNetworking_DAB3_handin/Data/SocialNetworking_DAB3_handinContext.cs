using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetworking_DAB3_handin.Models;

namespace SocialNetworking_DAB3_handin.Data
{
    public class SocialNetworking_DAB3_handinContext : DbContext
    {
        public SocialNetworking_DAB3_handinContext (DbContextOptions<SocialNetworking_DAB3_handinContext> options)
            : base(options)
        {
        }

        public DbSet<SocialNetworking_DAB3_handin.Models.Users> Users { get; set; }
    }
}

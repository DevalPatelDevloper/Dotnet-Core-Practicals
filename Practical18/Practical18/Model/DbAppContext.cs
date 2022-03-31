using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical18.Model
{
    public class DbAppContext : IdentityDbContext<User>
    {
        public DbAppContext(DbContextOptions<DbAppContext> options)
           : base(options)
        {
        }

    }
}

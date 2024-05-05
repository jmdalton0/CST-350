using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CST350.Models
{
    public class YourDbContext : DbContext
    {
        public DbSet<RegistrationViewModel> Registrations { get; set; }

        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
        {
        }
    }
}


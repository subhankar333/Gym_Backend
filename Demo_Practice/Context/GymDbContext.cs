using Demo_Practice.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_Practice.Context
{
    public class GymDbContext:DbContext
    {
        public GymDbContext(DbContextOptions options):base(options)
        {
            
        }



        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}

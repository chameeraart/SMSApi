using Microsoft.EntityFrameworkCore;

namespace SMSApi.Models
{
    public class SMSDbContext : DbContext
    {
        public SMSDbContext(DbContextOptions<SMSDbContext> options) : base(options)
        {

        }

        public DbSet<Student> students { get; set; }
        public DbSet<User> users { get; set; }
    }
}

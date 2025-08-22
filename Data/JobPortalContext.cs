using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class JobPortalContext : DbContext
    {
        public JobPortalContext(DbContextOptions<JobPortalContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}

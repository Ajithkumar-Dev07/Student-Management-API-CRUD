using Microsoft.EntityFrameworkCore;

namespace Student_Management_System.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Students> student { get; set; }
    }
}

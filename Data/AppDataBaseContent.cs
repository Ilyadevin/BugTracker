using BugTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data
{
    public class AppDataBaseContent: DbContext
    {
        public AppDataBaseContent(DbContextOptions<AppDataBaseContent> options) : base(options)
        { }
        public DbSet<Bugs> Bugs { get; set; }
        public DbSet<BugPriority> BugPriority { get; set; }
    }
}

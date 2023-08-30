using BugTracker.Data.Interfaces;
using BugTracker.Data.Models;
using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data
{
    public class AppDataBaseContent: DbContext
    {
        public DbSet<Bugs> Bugs { get; set; } = null;
        public DbSet<BugPriority> BugPriority { get; set; } = null;
        public AppDataBaseContent(DbContextOptions<AppDataBaseContent> options) : base(options)
        { 
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BugPriority>().HasData(
                    new BugPriority { BugClassName = "Low", Description = "Description", Id = 1 },
                    new BugPriority { BugClassName = "Medium", Description = "Description", Id = 2 },
                    new BugPriority { BugClassName = "High", Description = "Description", Id = 3 }
                );
            modelBuilder.Entity<Bugs>().HasData(
                new Bugs
                {
                    Name = "error in smth, low proirity",
                    IsSolved = false,
                    CreationDate = DateTime.Today.AddDays(-1),
                    //DateOfLastInteraction = DateTime.Today,
                    Id = Guid.NewGuid(),
                    LongDescription = "Long descr",
                    ShortDescription = "shortdescr",
                    PriorityID = 1,
                    //Priority = BugPriority.,
                    ScreenShot = "/img/34a012f9-68cf-4e21-81b2-2023d75c4f96.png"
                },
                new Bugs
                {
                    Name = "error in smth, middle priority",
                    IsSolved = false,
                    CreationDate = DateTime.Today.AddDays(-1),
                    DateOfLastInteraction = DateTime.Today,
                    Id = Guid.NewGuid(),
                    LongDescription = "Long descr",
                    ShortDescription = "shortdescr",
                    PriorityID = 2,
                    //Priority = bugPriority.AllBugPriorities.First(),
                    ScreenShot = "/img/34a012f9-68cf-4e21-81b2-2023d75c4f96.png"
                },
                new Bugs
                {
                    Name = "error in smth, high priority",
                    IsSolved = false,
                    CreationDate = DateTime.Today.AddDays(-1),
                    DateOfLastInteraction = DateTime.Today,
                    Id = Guid.NewGuid(),
                    LongDescription = "Long descr",
                    ShortDescription = "shortdescr",
                    PriorityID = 3,
                    //Priority = bugPriority.AllBugPriorities.First(),
                    ScreenShot = "/img/34a012f9-68cf-4e21-81b2-2023d75c4f96.png"
                });
                
        }
    }
}

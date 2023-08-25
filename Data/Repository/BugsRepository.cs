using BugTracker.Data.Interfaces;
using BugTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data.Repository
{
    public class BugsRepository : IBugs
    {
        private readonly AppDataBaseContent appDataBaseContent;
        public BugsRepository(AppDataBaseContent appDataBaseContent)
        {
            this.appDataBaseContent = appDataBaseContent;
        }
        public IEnumerable<Bugs> Bugs => appDataBaseContent.Bugs.Include(b => b.Priority);

        public IEnumerable<Bugs> getSolvedBugs => appDataBaseContent.Bugs.Where(p=>p.IsSolved).Include(b=>b.Priority);

        public Bugs getObjectBug(Guid BugId) => appDataBaseContent.Bugs.FirstOrDefault(p=>p.Id == BugId);
    }
}

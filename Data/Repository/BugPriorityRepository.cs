using BugTracker.Data.Interfaces;
using BugTracker.Data.Models;

namespace BugTracker.Data.Repository
{
    public class BugPriorityRepository : IBugPriority
    {
        private readonly AppDataBaseContent appDataBaseContent;
        public BugPriorityRepository(AppDataBaseContent appDataBaseContent)
        {
            this.appDataBaseContent = appDataBaseContent;
        }
        public IEnumerable<BugPriority> AllBugPriorities => appDataBaseContent.BugPriority;
    }
}

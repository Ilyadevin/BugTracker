using BugTracker.Data.Interfaces;
using BugTracker.Data.Models;

namespace BugTracker.Data.Mocs
{
    public class MockBugPriority : IBugPriority
    {
        public IEnumerable<BugPriority> AllBugPriorities
        {
            get
            {
                return new List<BugPriority>
                {
                    new BugPriority{ BugClassName = "Low", Description="Description", Id=1 },
                    new BugPriority{ BugClassName="Medium", Description="Description", Id=2 },
                    new BugPriority{ BugClassName="High", Description="Description", Id=3 }
                };
            }
        }
    }
}

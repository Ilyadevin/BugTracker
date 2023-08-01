using BugTracker.Data.Interfaces;
using BugTracker.Data.Models;

namespace BugTracker.Data.Mocs
{
    public class MockBugPriority : IBugPriority
    {
        public IEnumerable<BugPriority> AllBugPriorities {
            get
            {
                return new List<BugPriority>
                {
                    new BugPriority{ BugClassName = "low", LongDescription = "Long Description", ShortDescription="Short Description", Id=Guid.NewGuid() }
                };
            }
        }
    }
}

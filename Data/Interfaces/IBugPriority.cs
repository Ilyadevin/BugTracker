using BugTracker.Data.Models;

namespace BugTracker.Data.Interfaces
{
    public interface IBugPriority
    {
        IEnumerable<BugPriority> AllBugPriorities { get; }
    }
}

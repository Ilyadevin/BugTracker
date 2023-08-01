using BugTracker.Data.Models;

namespace BugTracker.Data.Interfaces
{
    public interface IBugs
    {
        IEnumerable<Bug> Bugs { get;}
        IEnumerable<Bug> getSolvedBugs {  get; set; }
        Bug getObjectBug(Guid BugId);
    }
}

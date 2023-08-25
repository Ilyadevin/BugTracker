using BugTracker.Data.Models;

namespace BugTracker.Data.Interfaces
{
    public interface IBugs
    {
        IEnumerable<Bugs> Bugs { get;}
        IEnumerable<Bugs> getSolvedBugs {  get; }
        Bugs getObjectBug(Guid BugId);
    }
}

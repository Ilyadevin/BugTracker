using BugTracker.Data.Models;

namespace BugTracker.Data.Interfaces
{
    public interface IBugs
    {
        IEnumerable<Bugs> Bugs { get;}
        IEnumerable<Bugs> getSolvedBugs {  get; set; }
        Bugs getObjectBug(Guid BugId);
    }
}

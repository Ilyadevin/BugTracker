using BugTracker.Data.Interfaces;
using BugTracker.Data.Models;

namespace BugTracker.Data.Mocs
{
    public class MockBugs : IBugs
    {
        private readonly IBugPriority bugPriority = new MockBugPriority();
        public IEnumerable<Bugs> Bugs { 
            get {
                return new List<Bugs>
                {
                    new Bugs{Name="error in smth", IsSolved=false, CreationDate=DateTime.Today.AddDays(-1), 
                        DateOfLastInteraction = DateTime.Today, Id = Guid.NewGuid(), LongDescription="Long descr", 
                        ShortDescription = "shortdescr", Priority =bugPriority.AllBugPriorities.First()}
                };
            }
        }
        public IEnumerable<Bugs> getSolvedBugs { get; set; }

        public Bugs getObjectBug(Guid BugId)
        {
            throw new NotImplementedException();
        }
    }
}

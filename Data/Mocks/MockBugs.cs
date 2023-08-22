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
                        ShortDescription = "shortdescr", Priority =bugPriority.AllBugPriorities.First(), ScreenShot = "/img/34a012f9-68cf-4e21-81b2-2023d75c4f96.png"}
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

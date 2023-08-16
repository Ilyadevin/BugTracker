using BugTracker.Data.Models;

namespace BugTracker.ViewModels
{
    public class BugsListViewModel
    {
        public IEnumerable<Bugs> AllBugs {  get; set; }
        public string CurrCategory { get; set; }
    }
}

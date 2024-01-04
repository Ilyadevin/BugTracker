using BugTracker.Data.Enum;
using BugTracker.Models;

namespace BugTracker.ViewModels
{
    public class ListBugByPriorityViewModel
    {
        public List<BugPriority> BugPriorities { get; set; } = null;
        //public IEnumerable<Bug> Bugs { get; set; }
       // public string Priority { get; set; }
    }
}

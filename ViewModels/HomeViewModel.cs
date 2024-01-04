using BugTracker.Models;

namespace BugTracker.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Bug>? bugs { get; set; }
        public HomeUserCreateViewModel Register { get; set; } = new HomeUserCreateViewModel();
    }
}
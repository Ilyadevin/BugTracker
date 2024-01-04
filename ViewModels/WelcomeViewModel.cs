using BugTracker.Models;
using BugTracker.Data;
using CloudinaryDotNet.Actions;

namespace BugTracker.ViewModels
{
    public class WelcomeViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
    }
}

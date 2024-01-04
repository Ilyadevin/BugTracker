using CloudinaryDotNet.Actions;

namespace BugTracker.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role role { get; set; }
    }
}

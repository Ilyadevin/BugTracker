namespace BugTracker.Data.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Roles role { get; set; }
    }
}

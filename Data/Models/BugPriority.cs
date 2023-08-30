namespace BugTracker.Data.Models
{
    /// <summary>
    /// BugPriority
    /// </summary>
    public class BugPriority
    {
        /// <summary>
        /// id of bug Priority
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// name of bug Priority
        /// </summary>
        public string? BugClassName { set; get; }
        /// <summary>
        /// description for priority
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// list of bugs of current category
        /// </summary>
        public ICollection<Bugs>? Bugs { get; set; }
        public BugPriority() { 
            Bugs = new List<Bugs>();
        }
    }
}

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
        public Guid Id { set; get; }
        /// <summary>
        /// name of bug Priority
        /// </summary>
        public string BugClassName { set; get; }
        public string ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        /// <summary>
        /// list of bugs of current category
        /// </summary>
        public List<Bug> Bugs { get; set; }

    }
}

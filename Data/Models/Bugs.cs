using System.ComponentModel.DataAnnotations;

namespace BugTracker.Data.Models
{
    public class Bugs
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Need to specify a name of bug")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Need to specify a short description")]
        public string ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        [Required(ErrorMessage = "Need to specify a date of bug appearance")]
        public DateTime CreationDate { get; set; }
        public DateTime? DateOfLastInteraction { get; set; }
        public string ScreenShot { get; set; }
        public bool IsSolved { get; set; }
        public int PriorityID { get; set; }
        public BugPriority Priority { get; set; }

    }
}

using BugTracker.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.ViewModels
{
    public class CreateBugViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DateOfLastInteraction { get; set; }
        public IFormFile ScreenShot { get; set; }
        public BugPriority Priority { get; set; }
        public bool IsSolved { get; set; }
        public string AppUserId { get; set; }
    }
}

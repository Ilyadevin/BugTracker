using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models
{
    public class AppUser : IdentityUser
    {
        public string? ProfileImageUrl { get; set; }
        public ICollection<Bug> Bugs { get; set; }
    }
}

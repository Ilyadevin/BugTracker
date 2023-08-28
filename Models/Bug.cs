﻿using BugTracker.Data.Models;

namespace BugTracker.Models
{
    public class Bug
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public string? ScreenShot { get; set; }
        public bool IsSolved { get; set; }
        public Guid PriorityID { get; set; }
        public BugPriority Priority { get; set; }
    }
}
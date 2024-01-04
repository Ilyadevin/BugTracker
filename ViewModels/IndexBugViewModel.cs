using BugTracker.Models;

namespace BugTracker.ViewModels;

public class IndexBugViewModel
{
    public IEnumerable<Bug> Bugs { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public int TotalBugs { get; set; }
    public int Priority { get; set; }
    public bool HasPreviousPage => Page > 1;

    public bool HasNextPage => Page < TotalPages;
}
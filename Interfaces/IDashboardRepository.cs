using BugTracker.Models;

namespace BugTracker.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Bug>> GetAllUserBugs();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Update(AppUser user);
        bool Save();
    }
}

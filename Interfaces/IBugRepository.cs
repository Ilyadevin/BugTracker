using BugTracker.Data.Enum;
using BugTracker.Models;

namespace BugTracker.Interfaces
{
    public interface IBugRepository
    {
        Task<IEnumerable<Bug>> GetAll();


        Task<IEnumerable<Bug>> GetBugsByPriorityAndSliceAsync(BugPriority priority, int offset, int size);

        Task<Bug?> GetByIdAsync(Guid id);

        Task<Bug?> GetByIdAsyncNoTracking(string id);

        Task<int> GetCountAsync();

        Task<int> GetCountByPriorityAsync(BugPriority priorityy);

        bool Add(Bug club);

        bool Update(Bug club);

        bool Delete(Bug club);

        bool Save();
    }
}

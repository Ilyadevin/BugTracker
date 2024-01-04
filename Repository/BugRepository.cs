using BugTracker.Data;
using BugTracker.Data.Enum;
using BugTracker.Interfaces;
using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Repository
{
    // TODO: make interfaces for bugrepository
    public class BugRepository : IBugRepository
    {
        private readonly ApplicationDbContext _context;

        public BugRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Bug club)
        {
            _context.Add(club);
            return Save();
        }

        public bool Delete(Bug club)
        {
            _context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Bug>> GetAll()
        {
            return await _context.Bugs.ToListAsync();
        }
        public async Task<IEnumerable<Bug>> GetBugsByPriorityAndSliceAsync(BugPriority priority, int offset, int size)
        {
            return await _context.Bugs
                .Include(i => i.Name)
                .Where(c => c.Priority == priority)
                .Skip(offset)
                .Take(size)
                .ToListAsync();
        }

        public async Task<int> GetCountByPriorityAsync(BugPriority priority)
        {
            return await _context.Bugs.CountAsync(c => c.Priority == priority);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Bug bug)
        {
            _context.Update(bug);
            return Save();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Bugs.CountAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
       // public Task<IEnumerable<Bug>> GetBugsByPriorityAndSliceAsync(BugPriority priority, int offset, int size)
      //  {
       //     throw new NotImplementedException();
     //   }

        public Task<Bug?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Bug?> GetByIdAsyncNoTracking(string id)
        {
            throw new NotImplementedException();
        }
    }
}

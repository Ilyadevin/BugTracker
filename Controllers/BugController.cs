using BugTracker.Data.Enum;
using BugTracker.Interfaces;
using BugTracker.Models;
using BugTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    public class BugController:Controller
    {
        private readonly IBugRepository _bugRepository;
        private readonly IPhotoService _photoService;

        public BugController(IBugRepository bugRepository, IPhotoService photoService)
        {
            _bugRepository = bugRepository;
            _photoService = photoService;
        }

        [HttpGet]
        [Route("Bugs")]
        public async Task<IActionResult> Index(int priority = -1, int page = 1, int pageSize = 6)
        {
            if (page < 1 || pageSize < 1)
            {
                return NotFound();
            }

            // if priority is -1 (All) dont filter else filter by selected priority
            var bugs = priority switch
            {
                _ => await _bugRepository.GetBugsByPriorityAndSliceAsync((BugPriority)priority, (page - 1) * pageSize, pageSize),
            };

            var count = priority switch
            {
                -1 => await _bugRepository.GetCountAsync(),
                _ => await _bugRepository.GetCountByPriorityAsync((BugPriority)priority),
            };

            var clubViewModel = new IndexBugViewModel
            {
                Bugs = bugs,
                Page = page,
                PageSize = pageSize,
                TotalBugs = count,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                Priority = priority,
            };

            return View(clubViewModel);
        }

        [HttpGet]
        [Route("bug/{runningClub}/{id}")]
        public async Task<IActionResult> DetailClub(Guid id, string runningClub)
        {
            var club = await _bugRepository.GetByIdAsync(id);

            return club == null ? NotFound() : View(club);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            var curUserId = HttpContext.User.GetUserId();
            var createBugViewModel = new CreateBugViewModel { AppUserId = curUserId };
            return View(createBugViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBugViewModel bugVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(bugVM.ScreenShot);

                var bug = new Bug
                {
                    Name = bugVM.Name,
                    ShortDescription = bugVM.ShortDescription,
                    LongDescription = bugVM.LongDescription,
                    CreationDate = bugVM.CreationDate,
                    DateOfLastInteraction = DateTime.UtcNow,
                    ScreenShot = result.Url.ToString(),
                    Priority = bugVM.Priority,
                    IsSolved = bugVM.IsSolved,
                    AppUserId = bugVM.AppUserId
                };
                _bugRepository.Add(bug);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(bugVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var bug = await _bugRepository.GetByIdAsync(id);
            if (bug == null) return View("Error");
            var bugVM = new EditBugViewModel
            {
                Id = id,
                Name = bug.Name,
                ShortDescription = bug.ShortDescription,
                LongDescription = bug.LongDescription,
                CreationDate = bug.CreationDate,
                DateOfLastInteraction = DateTime.UtcNow,
                Priority = bug.Priority,
                IsSolved = bug.IsSolved,
                AppUserId = bug.AppUserId
            };
            return View(bugVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditBugViewModel bugVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit bug");
                return View("Edit", bugVM);
            }

            var userBug = await _bugRepository.GetByIdAsyncNoTracking(id);

            if (userBug == null)
            {
                return View("Error");
            }

            var photoResult = await _photoService.AddPhotoAsync(bugVM.ScreenShot);

            if (photoResult.Error != null)
            {
                ModelState.AddModelError("Image", "Photo upload failed");
                return View(bugVM);
            }

            if (!string.IsNullOrEmpty(userBug.ScreenShot))
            {
                _ = _photoService.DeletePhotoAsync(userBug.ScreenShot);
            }

            var bug = new Bug
            {
                Name = bugVM.Name,
                ShortDescription = bugVM.ShortDescription,
                LongDescription = bugVM.LongDescription,
                CreationDate = bugVM.CreationDate,
                DateOfLastInteraction = DateTime.UtcNow,
                ScreenShot = photoResult.Url.ToString(),
                Priority = bugVM.Priority,
                IsSolved = bugVM.IsSolved,
                AppUserId = bugVM.AppUserId
            };

            _bugRepository.Update(bug);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var bugDetails = await _bugRepository.GetByIdAsync(id);
            if (bugDetails == null) return View("Error");
            return View(bugDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteBug(Guid id)
        {
            var bugDetails = await _bugRepository.GetByIdAsync(id);

            if (bugDetails == null)
            {
                return View("Error");
            }

            if (!string.IsNullOrEmpty(bugDetails.ScreenShot))
            {
                _ = _photoService.DeletePhotoAsync(bugDetails.ScreenShot);
            }

            _bugRepository.Delete(bugDetails);
            return RedirectToAction("Index");
        }
    }
}


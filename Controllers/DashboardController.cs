using BugTracker.Interfaces;
using BugTracker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RunGroopWebApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRespository;
        private readonly IPhotoService _photoService;

        public DashboardController(IDashboardRepository dashboardRespository,  IPhotoService photoService)
        {
            _dashboardRespository = dashboardRespository;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            var userBugs = await _dashboardRespository.GetAllUserBugs();
            var dashboardViewModel = new DashboardViewModel()
            {
                bugs = userBugs
            };
            return View(dashboardViewModel);
        }
    }
}
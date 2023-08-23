using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    public class NewBug : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

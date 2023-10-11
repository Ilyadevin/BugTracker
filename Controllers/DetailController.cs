using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

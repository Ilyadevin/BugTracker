using BugTracker.Data.Interfaces;
using BugTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    public class BugsController:Controller
    {
        private readonly IBugs _bugs;
        private readonly IBugPriority _bugPriority;
        public BugsController(IBugs bugs, IBugPriority bugPriority)
        {
            _bugs = bugs;
            _bugPriority = bugPriority;
        }
        public ViewResult List()
        {
            BugsListViewModel model = new BugsListViewModel();
            model.AllBugs = _bugs.Bugs;
            model.CurrCategory = "That is all founded bugss for today";
            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace WebDevFinalProject.Controllers
{
    public class WorkoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
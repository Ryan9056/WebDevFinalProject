using Microsoft.AspNetCore.Mvc;
using WebDevFinalProject.Data;
using WebDevFinalProject.Models;

namespace WebDevFinalProject.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly ApplicationDbContext data;

        public WorkoutController(ApplicationDbContext ctx)
        {
            data = ctx;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var workouts = data.Workouts.OrderBy(t => t.Date).ToList();
            return View(workouts);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var workout = data.Workouts.Find(id);

            if (workout == null)
            {
                return NotFound();
            }

            return View(workout);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View(new Workout());
        }

        [HttpPost]
        public IActionResult Add(Workout workout)
        {
            if (ModelState.IsValid)
            {
                bool exists = data.Workouts.Any(t => t.Date.Date == workout.Date.Date);

                if (exists)
                {
                    ModelState.AddModelError("", "Workout already exists for this date.");
                    return View(workout);
                }

                data.Workouts.Add(workout);
                data.SaveChanges();

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Please correct the errors below.");
            return View(workout);
        }

        [HttpGet]
        public IActionResult Related(int id)
        {
            var workout = data.Workouts.Find(id);

            if (workout == null)
            {
                return NotFound();
            }

            var exercises = data.Exercises
                .Where(t => t.Category == workout.WorkoutCategory)
                .OrderBy(t => t.Name)
                .ToList();

            ViewBag.WorkoutName = workout.Name;
            ViewBag.WorkoutCategory = workout.WorkoutCategory;

            return View(exercises);
        }
    }
}
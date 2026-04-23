using Microsoft.AspNetCore.Mvc;
using WebDevFinalProject.Models;
using WebDevFinalProject.Data;

namespace WebDevFinalProject.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly ApplicationDbContext data;

        public ExerciseController(ApplicationDbContext ctx)
        {
            data = ctx;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var exercises = data.Exercises.OrderBy(t => t.Name).ToList();
            return View(exercises);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var exercise = data.Exercises.Find(id);

            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View(new Exercise());
        }

        [HttpPost]
        public IActionResult Add(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                bool exists = data.Exercises.Any(t => t.Name == exercise.Name);

                if (exists)
                {
                    ModelState.AddModelError("", "Exercise already exists.");
                    return View(exercise);
                }

                data.Exercises.Add(exercise);
                data.SaveChanges();

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Please correct the errors below.");
            return View(exercise);
        }
    }
}
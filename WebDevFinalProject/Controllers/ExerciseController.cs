using Microsoft.AspNetCore.Mvc;
using WebDevFinalProject.Models;

namespace WebDevFinalProject.Controllers
{
    public class ExerciseController : Controller
    {
        public IActionResult Index()
        {
            var exercises = new List<Exercise>
            {
                new Exercise { Id = 1, Name = "Squats", Category = "Legs", Duration = 15, Difficulty = "Intermediate" },
                new Exercise { Id = 2, Name = "Push-Ups", Category = "Chest", Duration = 10, Difficulty = "Beginner" },
                new Exercise { Id = 3, Name = "Plank", Category = "Core", Duration = 5, Difficulty = "Beginner" }
            };

            return View(exercises);
        }

        public IActionResult Details(int id)
        {
            var exercise = new Exercise
            {
                Id = id,
                Name = "Sample Exercise",
                Category = "Full Body",
                Duration = 20,
                Difficulty = "Intermediate"
            };

            return View(exercise);
        }
    }
}

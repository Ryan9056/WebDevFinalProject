using Microsoft.AspNetCore.Mvc;
using WebDevFinalProject.Models;
using WebDevFinalProject.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebDevFinalProject.Controllers
{
    public class ExerciseController : Controller
    {

        private ApplicationDbContext data { get; set; }
        public ExerciseController(ApplicationDbContext ctx) => data = ctx;

        [HttpGet]
        public IActionResult Index()
        {
            var exercises = data.Exercises.OrderBy(t => t.Name).ToList();

            return View(exercises);
        }

        public IActionResult Details(int id)
        {

            var exercise = data.Exercises.Find(id);

            return View(exercise);
        }

        [HttpGet]
        public ViewResult Add() => View(new Exercise());


        [HttpPost]
        public IActionResult Add(Exercise exercise)
        {

            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    Console.WriteLine($"Field: {state.Key}, Error: {error.ErrorMessage}");
                }
            }
            if (ModelState.IsValid)
            {

                bool exists = data.Exercises.Any(t => t.Name == exercise.Name);

                if (exists)
                {
                    ModelState.AddModelError("", "Exercise already exists");
                    return View(exercise);
                }
                data.Exercises.Add(exercise);
                data.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Please correct the errors");
                return View(exercise);
            }
        }
        
    }
}

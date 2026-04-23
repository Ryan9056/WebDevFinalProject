using Microsoft.AspNetCore.Mvc;
using WebDevFinalProject.Data;

namespace WebDevFinalProject.Controllers
{
    public class ValidationController : Controller
    {
        private readonly ApplicationDbContext context;

        public ValidationController(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public JsonResult CheckName(string name)
        {
            bool exists = context.Exercises.Any(t => t.Name == name);

            if (exists)
            {
                return Json("Exercise is already entered.");
            }

            return Json(true);
        }

        public JsonResult CheckDate(string date)
        {
            if (!DateTime.TryParse(date, out DateTime parsedDate))
            {
                return Json("Please enter a valid date.");
            }

            bool exists = context.Workouts.Any(t => t.Date.Date == parsedDate.Date);

            if (exists)
            {
                return Json("A workout on this date is already entered.");
            }

            return Json(true);
        }
    }
}
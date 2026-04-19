using Microsoft.AspNetCore.Mvc;
using WebDevFinalProject.Data;

namespace WebDevFinalProject.Controllers
{
    public class ValidationController : Controller
    {
        private ApplicationDbContext context { get; set; }
        public ValidationController(ApplicationDbContext ctx) => context = ctx;

        public JsonResult CheckName(string name)
        {

            bool exists = context.Exercises.Any(t => t.Name == name);

            if (exists)
            {
                return Json("Exercise is already entered.");
            }

            return Json(true);
        }
    }
}

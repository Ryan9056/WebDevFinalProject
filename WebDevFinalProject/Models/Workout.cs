using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebDevFinalProject.Models
{
    public class Workout
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public string WorkoutCategory { get; set; } = "";
        [Remote(action: "CheckDate", controller: "Validation", ErrorMessage = "Date is already entered.")]
        public DateTime Date { get; set; }

    }
}

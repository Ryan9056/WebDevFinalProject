using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebDevFinalProject.Models
{
    public class Workout
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a workout name.")]
        [StringLength(50, ErrorMessage = "Workout name cannot exceed 50 characters.")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Please enter a workout category.")]
        [StringLength(30, ErrorMessage = "Workout category cannot exceed 30 characters.")]
        public string WorkoutCategory { get; set; } = "";

        [Required(ErrorMessage = "Please enter a date.")]
        [DataType(DataType.Date)]
        [Remote(action: "CheckDate", controller: "Validation", ErrorMessage = "Date is already entered.")]
        public DateTime Date { get; set; }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebDevFinalProject.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter an exercise name.")]
        [StringLength(50, ErrorMessage = "Exercise name cannot exceed 50 characters.")]
        [Remote(action: "CheckName", controller: "Validation", ErrorMessage = "Exercise is already entered.")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Please enter a category.")]
        [StringLength(30, ErrorMessage = "Category cannot exceed 30 characters.")]
        public string Category { get; set; } = "";

        [Required(ErrorMessage = "Please enter a duration.")]
        [Range(1, 180, ErrorMessage = "Duration must be between 1 and 180 minutes.")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Please enter a difficulty.")]
        [StringLength(20, ErrorMessage = "Difficulty cannot exceed 20 characters.")]
        public string Difficulty { get; set; } = "";
    }
}
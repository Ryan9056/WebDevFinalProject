using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebDevFinalProject.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        [Required]
        [Remote(action: "CheckName", controller: "Validation", ErrorMessage = "Exercise is already entered.")]
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public int Duration { get; set; }
        public string Difficulty { get; set; } = "";
    }
}
namespace WebDevFinalProject.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public int Duration { get; set; }
        public string Difficulty { get; set; } = "";
    }
}
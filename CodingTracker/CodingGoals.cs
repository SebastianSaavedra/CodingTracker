using System.ComponentModel.DataAnnotations;

namespace CodingTracker
{
    public class CodingGoals
    {
        public int Id { get; set; }

        [Required]
        public string? Goal { get; set; }
        public string? CreationDate { get; set; }
        public int? Hours { get; set; }
        [Required]
        public string Deadline { get; set; }
    }
}
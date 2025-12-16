using System.ComponentModel.DataAnnotations;

namespace coursesManangementApi.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        [Required]
        public DateTime ReviewDate { get; set; }
        // Foreign keys
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        // Navigation properties
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}

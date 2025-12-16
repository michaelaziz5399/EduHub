using System.ComponentModel.DataAnnotations;

namespace coursesManangementApi.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public string Title { get; set; }=string.Empty;
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public float DurationInHours { get; set; }
        public CourseLevel Level { get; set; }
        public string Url { get; set; }=string.Empty;
        public int? InstructorId { get; set; }

        // Navigation properties
        public Instructor? Instructor { get; set; }
        public ICollection<Section> Sections { get; set; }= new HashSet<Section>();
        public ICollection<Category> Categories { get; set; }= new HashSet<Category>();
        public ICollection<Enrollment> Enrollments { get; set; }= new HashSet<Enrollment>();
        public ICollection<Review> Reviews { get; set; }= new HashSet<Review>();
    }

    public enum CourseLevel
    {
        Beginner,
        Intermediate,
        Advanced
    }
}

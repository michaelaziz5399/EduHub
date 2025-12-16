using System.ComponentModel.DataAnnotations;

namespace coursesManangementApi.Models
{
    public class Enrollment
    {
        public DateTime EnrollmentDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletionDate { get; set; }
        [Range(0,100)]
        public float ProgressPercentage { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        // Navigation properties
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}

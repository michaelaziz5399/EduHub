namespace coursesManangementApi.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int UserId { get; set; }
        // Navigation property
        public User? User { get; set; }
        public ICollection<Enrollment> CourseEnrollments { get; set; } = new HashSet<Enrollment>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}

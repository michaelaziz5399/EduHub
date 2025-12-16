namespace coursesManangementApi.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Bio { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public string WebsiteUrl { get; set; } = string.Empty;
        public string Headline { get; set; } = string.Empty;
        public int UserId { get; set; }
        // Navigation property
        public User? User { get; set; }
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}

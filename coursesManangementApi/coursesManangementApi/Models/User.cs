namespace coursesManangementApi.Models
{
    public class User
    {
        public int  UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string   PasswordHach { get; set; }= string.Empty;
        public string Email { get; set; }= string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }

        public Instructor? InstructorProfile { get; set; }
        public Student? StudentProfile { get; set; }

    }
}

namespace coursesManangementApi.Dtos.Lesson
{
    public class CreateLessonDto
    {
        public string Title { get; set; } = string.Empty;
        public string VideoURL { get; set; } = string.Empty;
        public float DurationInMinutes { get; set; }
        public int Order { get; set; }
    }
}

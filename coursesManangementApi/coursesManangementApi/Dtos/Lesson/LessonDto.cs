namespace coursesManangementApi.Dtos.Lesson
{
    public class LessonDto
    {
        public int LessonId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string VideoURL { get; set; } = string.Empty;
        public float DurationInMinutes { get; set; }
        public int Order { get; set; }
    }
}

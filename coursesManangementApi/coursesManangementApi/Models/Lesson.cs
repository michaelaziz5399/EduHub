namespace coursesManangementApi.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string Title { get; set; }=string.Empty;
        public string VideoURL { get; set; }=string.Empty;
        public float DurationInMinutes { get; set; }
        public int Order { get; set; }
        public bool IsPreviewable { get; set; }
        public int SectionId { get; set; }

        // Navigation propertY
        public Section? Section { get; set; }
    }
}

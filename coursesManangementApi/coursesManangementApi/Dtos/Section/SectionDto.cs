using coursesManangementApi.Dtos.Lesson;

namespace coursesManangementApi.Dtos.Section
{
    public class SectionDto
    {
        public int SectionId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Order { get; set; }

        public ICollection<LessonDto> Lessons { get; set; } = new HashSet<LessonDto>();
    }
}

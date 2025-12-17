using coursesManangementApi.Dtos.Lesson;

namespace coursesManangementApi.Dtos.Section
{
    public class CreateSectionDto
    {
        public string Title { get; set; } = string.Empty;
        public int Order { get; set; }
        public ICollection<CreateLessonDto> Lessons { get; set; } = new HashSet<CreateLessonDto>();
    }
}

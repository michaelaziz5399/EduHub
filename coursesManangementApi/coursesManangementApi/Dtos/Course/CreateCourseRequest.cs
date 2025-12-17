using coursesManangementApi.Dtos.Section;

namespace coursesManangementApi.Dtos
{
    public class CreateCourseRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public float DurationInHours { get; set; }
        public string Level { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public int InstructorId { get; set; }
        public ICollection<CreateSectionDto> Sections { get; set; } = new HashSet<CreateSectionDto>();
    }
}

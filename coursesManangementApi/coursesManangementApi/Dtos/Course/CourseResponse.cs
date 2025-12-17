using coursesManangementApi.Dtos;
using coursesManangementApi.Dtos.Instructor;
using coursesManangementApi.Dtos.Section;
using coursesManangementApi.Models;
using System.ComponentModel.DataAnnotations;

namespace coursesManangementApi.Dtos
{
    public class CourseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public float DurationInHours { get; set; }
        public string Level { get; set; }= string.Empty;
        public string Url { get; set; } = string.Empty;


        // Navigation properties
        public InstructorDto? Instructor { get; set; }
        public ICollection<SectionDto> Sections { get; set; } = new HashSet<SectionDto>();
        public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}

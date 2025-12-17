using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace coursesManangementApi.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        public string Title { get; set; }=string.Empty;
        public int order { get; set; }
        public int CourseId { get; set; }

        // Navigation properties
        [JsonIgnore]
        public Course? Course { get; set; }
        public ICollection<Lesson> Lessons { get; set; } = new HashSet<Lesson>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace coursesManangementApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int? ParentId { get; set; }

        // Navigation properties
        public Category? Parent { get; set; }
        public ICollection<Category> Children { get; set; } = new HashSet<Category>();

        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();

    }
}

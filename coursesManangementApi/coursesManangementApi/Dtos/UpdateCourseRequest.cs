namespace coursesManangementApi.Dtos
{
    public class UpdateCourseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public float Price { get; set; }
        public float DiscountPrice { get; set; }
        public string Url { get; set; } = string.Empty;
        public bool IsPublished { get; set; }
    }
}

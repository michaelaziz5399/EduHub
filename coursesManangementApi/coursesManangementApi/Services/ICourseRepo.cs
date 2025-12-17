using coursesManangementApi.Dtos;
using coursesManangementApi.Models;

namespace coursesManangementApi.Services
{
    public interface ICourseRepo
    {
        Task<List<CourseResponse>> GetAllCoursesAsync();
        Task<CourseResponse?> GetByIdAsync(int id);
        Task<bool> AddCourseAsync(CreateCourseRequest courseDto);
        Task<bool> UpdateCourseAsync(int id, UpdateCourseRequest courseDto);
        Task<bool> DeleteCourseAsync(int id);
    }
}

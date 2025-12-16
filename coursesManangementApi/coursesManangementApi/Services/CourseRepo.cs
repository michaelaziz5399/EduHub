using coursesManangementApi.Data;
using coursesManangementApi.Dtos;
using coursesManangementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace coursesManangementApi.Services
{
    public class CourseRepo(AppDbContext _context) : ICourseRepo
    {
        public Task<bool> AddCourseAsync(CreateCourseRequest course)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseResponse>> GetAllCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CourseResponse?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCourseAsync(int id, UpdateCourseRequest course)
        {
            throw new NotImplementedException();
        }
    }
}

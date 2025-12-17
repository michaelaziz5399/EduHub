using AutoMapper;
using coursesManangementApi.Data;
using coursesManangementApi.Dtos;
using coursesManangementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace coursesManangementApi.Services
{
    public class CourseRepo(AppDbContext _context, IMapper mapper) : ICourseRepo
    {
        public async Task<bool> AddCourseAsync(CreateCourseRequest courseDto)
        {
            var newCourse = mapper.Map<Course>(courseDto);
            await _context.Courses.AddAsync(newCourse);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return false;
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CourseResponse>> GetAllCoursesAsync()
            => await _context.Courses
                .Include(s => s.Sections)
                  .ThenInclude(lessons => lessons.Lessons)
                .Include(i => i.Instructor)
                  .ThenInclude(user => user!.User)
                  .Include(c => c.Categories)
               .Select(course => mapper.Map<CourseResponse>(course))
               .ToListAsync();            

        public async Task<CourseResponse?> GetByIdAsync(int id)
        {
            var course = await  _context.Courses
                .Include(s => s.Sections)
                  .ThenInclude(lessons => lessons.Lessons)
                .Include(i => i.Instructor)
                  .ThenInclude(user => user!.User)
                  .Include(c => c.Categories)
               .FirstOrDefaultAsync(c => c.Id == id);
            if (course == null)
                return null;
            var courseDto = mapper.Map<CourseResponse>(course);
            return courseDto;
        }

        public async Task<bool> UpdateCourseAsync(int id, UpdateCourseRequest courseDto)
        {
            if (id != courseDto.Id)
                return false;
            var existingCourse =await  _context.Courses.FindAsync(id);
            if (existingCourse == null)
                return false;
            mapper.Map(courseDto, existingCourse);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return false;
            }
            return true;
        }
    }
}

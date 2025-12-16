using coursesManangementApi.Data;
using coursesManangementApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace coursesManangementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCourseController(AppDbContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            var courses = await _context.Courses
                .Include(s=> s.Sections)
                .ThenInclude(lessons => lessons.Lessons)
                .ToListAsync();

            return Ok(courses);
        }

    }
}

using coursesManangementApi.Dtos;
using coursesManangementApi.Models;
using coursesManangementApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coursesManangementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesManagementController(ICourseRepo courseRepo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<CourseResponse>>> GetAllCourses()
        {
            var courses = await courseRepo.GetAllCoursesAsync();
            if (courses is null)
            {
                return NotFound("courses is empty");
            }
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseResponse>> GetCourseById(int id)
        {
            var course = await courseRepo.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound("course not found");
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult> AddCourse([FromBody] CreateCourseRequest courseDto)
        {
            var result = await courseRepo.AddCourseAsync(courseDto);
            if (result)
            {
                return Ok("course added successfully");
            }
            return BadRequest("failed to add course");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var result = await courseRepo.DeleteCourseAsync(id);
            if (result)
            {
                return Ok("course deleted successfully");
            }
            return NotFound("course not found");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCourse(int id, [FromBody] UpdateCourseRequest courseDto)
        {
            var result = await courseRepo.UpdateCourseAsync(id, courseDto);
            if (result)
            {
                return Ok("course updated successfully");
            }
            return NotFound("course not found");
        }
    }
}

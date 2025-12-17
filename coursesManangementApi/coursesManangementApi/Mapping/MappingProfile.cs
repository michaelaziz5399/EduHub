using AutoMapper;
using coursesManangementApi.Dtos;
using coursesManangementApi.Dtos.Instructor;
using coursesManangementApi.Dtos.Lesson;
using coursesManangementApi.Dtos.Section;
using coursesManangementApi.Models;

namespace coursesManangementApi.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            // Mapping for Instructor to InstructorDto
            CreateMap<Instructor, InstructorDto>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.User!.FirstName} {src.User.LastName}")
                );
            // Mapping for Course to CourseResponse
            CreateMap<Course, CourseResponse>()
                .ForMember(
                    dest => dest.Level,
                    opt => opt.MapFrom(src => src.Level.ToString())
                )
                .ForMember(
                    dest=> dest.Instructor,
                    opt => opt.MapFrom(src => src.Instructor != null ? src.Instructor : null)
                );
            // Mapping for Section to SectionDto and Lesson to LessonDto
            CreateMap<Section, SectionDto>();
            CreateMap<Lesson, LessonDto>();


            
            CreateMap<CreateCourseRequest, Course>();
            CreateMap<CreateSectionDto, Section>();
            CreateMap<CreateLessonDto, Lesson>();
        }
    }
}

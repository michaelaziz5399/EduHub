using coursesManangementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace coursesManangementApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
       public DbSet<Course> Courses { get; set; }
       public DbSet<Section> Sections { get; set; }
       public DbSet<Lesson> Lessons { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<Review> Reviews { get; set; }
       public DbSet<Student> Students { get; set; }
       public DbSet<Instructor> Instructors { get; set; }
       public DbSet<Enrollment> Enrollments { get; set; }
       public DbSet<CourseCategory> CourseCategories { get; set; }
       public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Unique constraints for ordering within Course , Section and Reviews
            modelBuilder.Entity<Section>()
                .HasIndex(s => new { s.CourseId, s.order })
                .IsUnique();
            modelBuilder.Entity<Lesson>()
                .HasIndex(l => new { l.SectionId, l.Order })
                .IsUnique();
            modelBuilder.Entity<Review>()
               .HasIndex(r => new { r.StudentId, r.CourseId })
               .IsUnique();

            // Configure one-to-many relationship between Section and Lesson
            modelBuilder.Entity<Section>()
                .HasMany(s => s.Lessons)
                .WithOne(l => l.Section)
                .HasForeignKey(l => l.SectionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Configure one-to-many relationship between Course and Section
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Sections)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Self-referencing relationship for Category (Parent-Child)
            modelBuilder.Entity<Category>()
                .HasMany(c=>c.Children)
                .WithOne(c=>c.Parent)
                .HasForeignKey(c=>c.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            // Many-to-Many relationship between Course and Category via CourseCategory
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Categories)
                .WithMany(cat => cat.Courses)
                .UsingEntity<CourseCategory>(
                    j => j
                        .HasOne(cc => cc.Category)
                        .WithMany()
                        .HasForeignKey(cc => cc.CategoryId),
                    j => j
                        .HasOne(cc => cc.Course)
                        .WithMany()
                        .HasForeignKey(cc => cc.CourseId),
                    j =>
                    {
                        j.HasKey(t => new { t.CourseId, t.CategoryId });
                    });

            // Configure Enrollment entity relationships
            modelBuilder.Entity<Course>()
                .HasMany(c=>c.Enrollments)
                .WithOne(c=>c.Course)
                .HasForeignKey(c=>c.CourseId)
                .OnDelete(DeleteBehavior.Restrict);// Prevent cascade delete to avoid accidental data loss

            modelBuilder.Entity<Student>()
                .HasMany(s=>s.CourseEnrollments)
                .WithOne(e=>e.Student)
                .HasForeignKey(e=>e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);// Cascade delete enrollments when a student is deleted

            // Composite primary key for Enrollment
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId });

            // Configure Review entity relationships
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Reviews)
                .WithOne(r => r.Student)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Reviews)
                .WithOne(r => r.Course)
                .HasForeignKey(r => r.CourseId)
                .OnDelete(DeleteBehavior.Cascade);


            // Configure Instructor entity relationships
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.User) // An instructor has one user profile
                .WithOne(u => u.InstructorProfile) // The user profile has one instructor
                .HasForeignKey<Instructor>(i => i.UserId)
                .IsRequired();

            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.Courses) // An instructor can have many courses
                .WithOne(c => c.Instructor) // Each course has one instructor
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.SetNull); // Set InstructorId to null if the instructor is deleted

            // Configure Student entity relationships
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User) // A student has one user profile
                .WithOne(u => u.StudentProfile) // The user profile has one student
                .HasForeignKey<Student>(s => s.UserId)
                .IsRequired();


            // Configure decimal precision for Price and DiscountPrice in Course
            modelBuilder.Entity<Course>()
               .Property(c => c.Price)
               .HasColumnType("decimal(18, 2)"); // Set precision and scale

            modelBuilder.Entity<Course>()
                .Property(c => c.DiscountPrice)
                .HasColumnType("decimal(18, 2)");

            // Call the base method
            base.OnModelCreating(modelBuilder);
        }
    }
}

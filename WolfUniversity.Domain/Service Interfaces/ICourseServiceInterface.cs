
namespace WolfUniversity.Domain
{
    public interface ICourseServiceInterface
    {
       // Task<Course> GetCourseById(int id);
        
        Task<List<Course>> GetAllCourses();

        Task<Course> AddCourse(Course course);
        Task<Course> UpdateCourse(Course course);

        Task<bool> DeleteCourse(Course course);
    }
}

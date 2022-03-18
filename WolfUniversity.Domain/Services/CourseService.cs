
namespace WolfUniversity.Domain
{
    public class CourseService :BaseService, ICourseServiceInterface
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork): base(unitOfWork)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Course> GetCourseById(int id)
        {
            var course = await _courseRepository.GetAsync(c => c.CourseId == id);
            return course;
        }
        public async Task<List<Course>> GetAllCourses()
        {
            var courses = await _courseRepository.ListAsync();
            return courses;
        }

        public async Task<Course> AddCourse(Course course)
        {
          var courses=  await _courseRepository.AddAsync(course);
            await UnitOfWork.CommitAsync();
            return courses;
        }

        public  async Task<Course> UpdateCourse(Course course)
        {
            var courses =await _courseRepository.UpdateAsync(course);
            await UnitOfWork.CommitAsync();
            return courses;
        }

        public async Task<bool> DeleteCourse(Course course)
        {
          return  await _courseRepository.DeleteAsync(course);
        }

        public async Task<int> CountCourses()
        {
            return await _courseRepository.CountAsync();
        }
    }
}

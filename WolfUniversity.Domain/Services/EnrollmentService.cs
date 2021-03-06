

namespace WolfUniversity.Domain
{
    public class EnrollmentService : BaseService, IEnrollmentServiceInterface
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository,IStudentRepository studentRepository, 
                                ICourseRepository courseRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }
      
        public async Task<Enrollment> AddEnrollmentAsync(Enrollment model)
        {
            var enrollment = await _enrollmentRepository.AddAsync(model);
            await UnitOfWork.CommitAsync();
            return enrollment;
        }

        public async Task<Enrollment> UpdateEnrollmentAsync(Enrollment model)
        {
            var enrollment = await _enrollmentRepository.UpdateAsync(model);
            await UnitOfWork.CommitAsync();
            return enrollment;
        }
        public async Task<Enrollment> GetEnrollmentByStudentNumberAsync(string studentNumber)
        {
            var student = await _studentRepository.GetAsync(c => c.StudentNumber == studentNumber);
            var enrollment =  _enrollmentRepository.GetAsync(e => e.StudentId == student.StudentId).Result;
            return enrollment;
        }
        public async Task<List<Enrollment>> GetAllEnrollmentsByCourseAsync(string courseName)
        {
            var course = await _courseRepository.GetAsync(c=>c.Name == courseName);
            var enrollments =  _enrollmentRepository.ListAsync(e => e.CourseId == course.CourseId).Result;
            return enrollments;
        }
    }  
}

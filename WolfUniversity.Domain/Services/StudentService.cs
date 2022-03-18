
namespace WolfUniversity.Domain
{
    public class StudentService : BaseService, IStudentServiceInterface
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _studentRepository.GetAsync(c=>c.StudentId==id);
            return student;
        }
        public async Task<List<Student>> GetAllStudents()
        {
            var students = await _studentRepository.ListAsync();
            return students;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var students = await _studentRepository.AddAsync(student);
            await UnitOfWork.CommitAsync();
            return students;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var students = await _studentRepository.UpdateAsync(student);
            await UnitOfWork.CommitAsync();
            return students;
        }

        public async Task<bool> DeleteStudent(Student student)
        {
         return  await _studentRepository.DeleteAsync(student);
        }

        public async Task<int> CountStudents()
        {
            return await _studentRepository.CountAsync();
        }
    }
}

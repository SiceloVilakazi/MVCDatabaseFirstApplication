
namespace WolfUniversity.Domain
{
    public class StudentService : BaseService, IStudentServiceInterface
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _studentRepository = studentRepository;
        }

        //TODO
        //public async Task<Student> GetStudentById(int id)
        //{
        //    var student = await _studentRepository.GetAsync(s=>true,id);
        //    return student;
        //}
        public async Task<List<Student>> GetAllStudents()
        {
            var students = await _studentRepository.ListAsync(s=>true);
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
    }
}

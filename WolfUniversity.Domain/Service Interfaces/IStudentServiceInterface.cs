namespace WolfUniversity.Domain
{
    public interface IStudentServiceInterface
    {
       // Task<Student> GetStudentById(int id);

        Task<List<Student>> GetAllStudents();

        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);

        Task<bool> DeleteStudent(Student student);
    }
}

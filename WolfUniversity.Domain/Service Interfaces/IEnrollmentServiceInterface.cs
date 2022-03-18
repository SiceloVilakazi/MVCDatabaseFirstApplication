namespace WolfUniversity.Domain
{
    public interface IEnrollmentServiceInterface
    {
        Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment);

        Task<Enrollment> UpdateEnrollmentAsync(Enrollment enrollment);

        Task<Enrollment> GetEnrollmentByStudentNumberAsync(string studentNumber);

        Task<List<Enrollment>> GetAllEnrollmentsByCourseAsync(string courseName);
    }
}

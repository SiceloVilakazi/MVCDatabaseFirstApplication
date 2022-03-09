
using WolfUniversity.Domain;

namespace WolfUniversity.Infrastructure
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(WolfUniversityDBContext dBContext): base(dBContext)
        { }
    }
}

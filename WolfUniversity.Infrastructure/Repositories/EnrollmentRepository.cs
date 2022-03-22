
using WolfUniversity.Domain;

namespace WolfUniversity.Infrastructure
{
    public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(WolfUniversityDBContext dBContext) : base(dBContext)
        {
        }
    }
}


using WolfUniversity.Domain;

namespace WolfUniversity.Infrastructure
{
    public class CourseRepository :BaseRepository<Course>,ICourseRepository
    {
        public CourseRepository(WolfUniversityDBContext dBContext) : base(dBContext)
        { }
    }
}

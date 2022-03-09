
using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Queries
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, List<Course>>
    {
        private readonly ICourseServiceInterface _courseService;

        public GetCoursesQueryHandler(ICourseServiceInterface courseServiceInterface)
        {
            _courseService = courseServiceInterface;
        }

        public async Task<List<Course>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseService.GetAllCourses();
            return course;
        }
    }
}

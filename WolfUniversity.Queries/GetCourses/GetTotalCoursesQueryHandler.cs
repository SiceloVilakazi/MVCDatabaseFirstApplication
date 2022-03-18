
using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Queries
{
    public class GetTotalCoursesQueryHandler : IRequestHandler<GetTotalCoursesQuery, int>
    {
        private readonly ICourseServiceInterface _courseService;

        public GetTotalCoursesQueryHandler(ICourseServiceInterface courseService)
        {
            _courseService = courseService;
        }
        public Task<int> Handle(GetTotalCoursesQuery request, CancellationToken cancellationToken)
        {
            var totalCourses = _courseService.CountCourses();
            return totalCourses;
        }
    }
}

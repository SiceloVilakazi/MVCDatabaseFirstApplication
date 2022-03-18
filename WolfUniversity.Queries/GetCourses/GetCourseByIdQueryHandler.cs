using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Queries
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, Course>
    {
        private readonly ICourseServiceInterface _courseService;

        public GetCourseByIdQueryHandler(ICourseServiceInterface courseServiceInterface)
        {
            _courseService = courseServiceInterface;
        }

        public async Task<Course> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseService.GetCourseById(request.courseId);
            return course;
        }
    }
}

using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Commands
{
    public class AddCourseCommandHandler : IRequestHandler<AddCourseCommand, Course>
    {
        private readonly ICourseServiceInterface _courseService;

        public AddCourseCommandHandler(ICourseServiceInterface courseService)
        {
            _courseService = courseService;
        }
        public async Task<Course> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseService.AddCourse(request.Course);
            return course;
        }
    }
}

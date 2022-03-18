using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Commands
{
    public class EditCourseCommandHandler : IRequestHandler<EditCourseCommand, Course>
    {
        private readonly ICourseServiceInterface _courseService;

        public EditCourseCommandHandler(ICourseServiceInterface courseService)
        {
            _courseService = courseService;
        }

        public async Task<Course> Handle(EditCourseCommand request, CancellationToken cancellationToken)
        {
            var updatedCourse = await _courseService.UpdateCourse(request.Course);
            return updatedCourse;
        }
    }
}

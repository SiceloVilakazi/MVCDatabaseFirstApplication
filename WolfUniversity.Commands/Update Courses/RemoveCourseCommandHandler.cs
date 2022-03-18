using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Commands
{
    public class RemoveCourseCommandHandler : IRequestHandler<RemoveCourseCommand, bool>
    {
        private readonly ICourseServiceInterface _courseService;

        public RemoveCourseCommandHandler(ICourseServiceInterface courseService)
        {
            _courseService = courseService;
        }
        public async Task<bool> Handle(RemoveCourseCommand request, CancellationToken cancellationToken)
        {
            var response = await _courseService.DeleteCourse(request.Course);
            return response;
        }
    }
}

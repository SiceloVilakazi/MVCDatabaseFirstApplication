using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Queries
{
    public class GetEnrollmentsByCourseQueryHandler : IRequestHandler<GetEnrollmentsByCourseQuery, List<Enrollment>>
    {
        private readonly IEnrollmentServiceInterface _environmentService;

        public GetEnrollmentsByCourseQueryHandler(IEnrollmentServiceInterface enrollmentService)
        {
            _environmentService = enrollmentService;
        }
        public async Task<List<Enrollment>> Handle(GetEnrollmentsByCourseQuery request, CancellationToken cancellationToken)
        {
            var enrollment = await _environmentService.GetAllEnrollmentsByCourseAsync(request.CourseName);
            return enrollment;
         
        }
    }
}

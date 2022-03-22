
using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Queries
{
    public class GetEnrollmentByStudentNumberQueryHandler : IRequestHandler<GetEnrollmentByStudentNumberQuery, Enrollment>
    {
        private readonly IEnrollmentServiceInterface _environmentService;

        public GetEnrollmentByStudentNumberQueryHandler(IEnrollmentServiceInterface enrollmentService)
        {
            _environmentService = enrollmentService;
        }
        public Task<Enrollment> Handle(GetEnrollmentByStudentNumberQuery request, CancellationToken cancellationToken)
        {
            var enrollments = _environmentService.GetEnrollmentByStudentNumberAsync(request.StudentNumber);
            return enrollments;
        }
    }
}

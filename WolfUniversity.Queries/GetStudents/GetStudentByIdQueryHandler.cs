
using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Queries
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly IStudentServiceInterface _studentService;

        public GetStudentByIdQueryHandler(IStudentServiceInterface studentService)
        {
              _studentService = studentService;
        }

        public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentById(request.studentId);
            return student;
        }
    }
}

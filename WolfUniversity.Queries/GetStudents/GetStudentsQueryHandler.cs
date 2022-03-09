
using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Queries
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<Student>>
    {
        private readonly IStudentServiceInterface _studentService;

        public GetStudentsQueryHandler(IStudentServiceInterface studentService)
        {
            _studentService = studentService;
        }

        public async Task<List<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetAllStudents();
            return students;
        }
    }
}

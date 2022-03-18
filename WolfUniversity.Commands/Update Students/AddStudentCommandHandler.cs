using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Commands
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, Student>
    {
        public IStudentServiceInterface _studentService { get; set; }

        public AddStudentCommandHandler(IStudentServiceInterface studentService)
        {
            _studentService = studentService;
        }

        public async Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.AddStudent(request.Student);
            return student;
        }
    }
}

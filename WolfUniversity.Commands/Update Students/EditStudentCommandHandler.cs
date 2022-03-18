using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Commands
{
    public class EditStudentCommandHandler : IRequestHandler<EditStudentCommand, Student>
    {
        public IStudentServiceInterface _studentService { get; set; }

        public EditStudentCommandHandler(IStudentServiceInterface studentService)
        {
            _studentService = studentService;
        }

        public async Task<Student> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.UpdateStudent(request.Student);
            return student;
        }
    }
}

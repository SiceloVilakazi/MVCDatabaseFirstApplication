
using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Commands
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand, bool>
    {
        public IStudentServiceInterface _studentService { get; set; }
        public RemoveStudentCommandHandler(IStudentServiceInterface studentService)
        {
            _studentService = studentService;
        }
        public async Task<bool> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var response = await _studentService.DeleteStudent(request.student);
            return response;
        }
    }
}

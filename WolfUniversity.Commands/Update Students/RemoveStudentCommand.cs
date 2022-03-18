using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Commands
{
    public class RemoveStudentCommand : IRequest<bool>
    {
        public Student student { get; set; } = null!;
    }
}

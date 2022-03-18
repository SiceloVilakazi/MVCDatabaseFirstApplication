using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Commands
{
    public class RemoveCourseCommand : IRequest<bool>
    {
        public Course Course { get; set; } = null!;
    }
}

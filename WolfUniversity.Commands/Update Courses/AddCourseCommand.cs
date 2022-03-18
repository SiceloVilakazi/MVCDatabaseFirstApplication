using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Commands
{
    public class AddCourseCommand : IRequest<Course>
    {
        public Course Course { get; set; }

        public AddCourseCommand(Course course)
        {
            Course = course;
        }
    }
}

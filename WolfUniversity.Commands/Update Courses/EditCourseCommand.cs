using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Commands
{
    public class EditCourseCommand : IRequest<Course>
    {
        public Course Course { get; set; }

        public EditCourseCommand(Course course)
        {
               Course = course;
        }
    }
}

using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Commands
{
    public class EditStudentCommand : IRequest<Student>
    {
        public Student Student { get; set; } = null!;

        public EditStudentCommand(Student student)
        {
            Student = student;
        }
    }
}

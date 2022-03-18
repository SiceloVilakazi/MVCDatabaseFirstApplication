using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Commands
{
    public class AddStudentCommand : IRequest<Student>
    {
        public Student Student { get; set; }=null!;

        public AddStudentCommand(Student student)
        {
            Student = student;
        }
    }
}

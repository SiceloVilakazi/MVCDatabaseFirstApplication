
using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Queries
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int studentId { get; }

        public GetStudentByIdQuery(int id)
        {
            studentId = id;
        }
    }
}

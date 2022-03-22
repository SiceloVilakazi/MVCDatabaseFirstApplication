using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Queries
{
    public class GetEnrollmentByStudentNumberQuery : IRequest<Enrollment>
    {
        public string StudentNumber { get; }

        public GetEnrollmentByStudentNumberQuery(string studentNumber)
        {
            StudentNumber = studentNumber;
        }
    }
}

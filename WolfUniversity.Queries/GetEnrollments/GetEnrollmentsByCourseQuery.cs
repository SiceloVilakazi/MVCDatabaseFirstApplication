using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Queries
{
    public class GetEnrollmentsByCourseQuery : IRequest<List<Enrollment>>
    {
        public string CourseName { get; set; }
        public GetEnrollmentsByCourseQuery(string courseName)
        {
            CourseName = courseName;
        }
    }
}

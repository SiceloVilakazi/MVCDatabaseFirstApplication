using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Queries
{
    public class GetCourseByIdQuery : IRequest<Course>
    {
        public int courseId { get; set; }

        public GetCourseByIdQuery(int id)
        {
            courseId = id;
        }
    }
}

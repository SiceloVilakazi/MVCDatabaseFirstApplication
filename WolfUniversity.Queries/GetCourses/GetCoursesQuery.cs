using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Queries
{
    public class GetCoursesQuery :IRequest<List<Course>>
    { }
}

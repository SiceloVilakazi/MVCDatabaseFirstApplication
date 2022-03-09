

using MediatR;
using WolfUniversity.Domain;

namespace WolfUniversity.Queries
{
    public class GetStudentsQuery :IRequest<List<Student>>
    { }
}

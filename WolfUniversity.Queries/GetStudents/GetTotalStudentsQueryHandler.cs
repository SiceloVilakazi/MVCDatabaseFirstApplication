using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfUniversity.Domain;

namespace WolfUniversity.Queries
{
    public class GetTotalStudentsQueryHandler : IRequestHandler<GetTotalStudentsQuery, int>
    {
        private readonly IStudentServiceInterface _studentService;

        public GetTotalStudentsQueryHandler(IStudentServiceInterface studentService)
        {
            _studentService = studentService;
        }

        public Task<int> Handle(GetTotalStudentsQuery request, CancellationToken cancellationToken)
        {
            var totalStudents = _studentService.CountStudents();
            return totalStudents;
        }
    }
}

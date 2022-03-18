using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfUniversity.Queries
{
    public class GetTotalStudentsQuery : IRequest<int>
    {
    }
}

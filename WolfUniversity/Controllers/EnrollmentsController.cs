using Microsoft.AspNetCore.Mvc;
using WolfUniversity.Queries;

namespace WolfUniversity.Controllers
{
    public class EnrollmentsController : Controller
    {
        private IMediator _mediator;

        public EnrollmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> GetByCourse(string courseName)
        {
            var query = new GetEnrollmentsByCourseQuery(courseName);
            var result = await _mediator.Send(query);
            return View(result);
        }
        public async Task<IActionResult> GetByStudentNumber(string StudentNumber)
        {
            var query = new GetEnrollmentByStudentNumberQuery(StudentNumber);
            var result = await _mediator.Send(query);
            return View(result);
        }
    }
}

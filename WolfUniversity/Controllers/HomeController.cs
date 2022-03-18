using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WolfUniversity.Models;
using WolfUniversity.Queries;

namespace WolfUniversity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        public HomeController(ILogger<HomeController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async  Task<IActionResult> Index()
        {
            var coursesQuery = new GetTotalCoursesQuery();
            var totalCourses = await _mediator.Send(coursesQuery);

            var studentQuery = new GetTotalStudentsQuery();
            var totalStudents = _mediator.Send(studentQuery);

           DashboardViewModel dashboardViewModel = new DashboardViewModel();
           dashboardViewModel.TotalCourses = totalCourses;
           dashboardViewModel.TotalStudents = totalStudents.Result;
           

            return View(dashboardViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
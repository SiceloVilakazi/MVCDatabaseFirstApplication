using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WolfUniversity.Commands;
using WolfUniversity.Domain;
using WolfUniversity.Queries;

namespace WolfUniversity.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IMediator _mediator;
        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: CoursesController
        public async Task<IActionResult> Index()
        {
            var query = new GetCoursesQuery();
            var result = await _mediator.Send(query);
            return View(result);
        }

        // GET: CoursesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var query = new GetCourseByIdQuery(id);
            var result = await _mediator.Send(query);
            return View(result);
        }

        // GET: CoursesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoursesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,CourseCode,Name,Nqflevel,Description,CourseDuration,IsActive,LastModifiedBy,LastModifiedDate")] Course course)
        {
            var query = new AddCourseCommand(course);
            if (ModelState.IsValid)
            {
                await _mediator.Send(query);
                return RedirectToAction(nameof(Index));
            }
            return View(course);

        }

        // GET: CoursesController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var query = new GetCourseByIdQuery((int)id);
            var course =  _mediator.Send(query);

            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: CoursesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("CourseId,CourseCode,Name,Nqflevel,Description,CourseDuration,IsActive,LastModifiedBy,LastModifiedDate")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var query = new EditCourseCommand(course);
                    await _mediator.Send(query);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    //TODO write an exception
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: CoursesController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) {  return NotFound();}

            var query = new GetCourseByIdQuery((int)id);
            var course = await _mediator.Send(query);

            if (course == null) { return NotFound(); }

            return View(course);
        }


        // POST: CoursesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var getGuery = new GetCourseByIdQuery(id);
            var course = await _mediator.Send(getGuery);

            var DeleteCommand = new RemoveCourseCommand();
            await _mediator.Send(DeleteCommand);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
